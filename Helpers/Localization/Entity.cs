using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Shoes_Ecommerce.Helpers.Localization
{
    public static class EntityHelper
    {
        public static IEnumerable<object> FilterEntitiesByLanguage<T>(IEnumerable<T> entities, string lan)
        {
            // التحقق مما إذا كان الكيان هو من نوع Product
            if (typeof(T) == typeof(Product))
            {
                return FilterProducts(entities.Cast<Product>(), lan);
            }

            // إذا كان الكيان ليس من نوع Product، يتم التعامل معه بشكل ديناميكي
            return entities.Select(entity =>
            {
                var entityType = entity.GetType();
                var properties = entityType.GetProperties();

                // إنشاء كائن جديد باستخدام Dictionary لتعديل الخصائص ديناميكيًا
                var result = new Dictionary<string, object>();

                foreach (var property in properties)
                {
                    if (property.GetIndexParameters().Length > 0 || !property.CanRead) // تجاهل الخصائص غير القابلة للقراءة أو التي تحتوي على معلمات
                        continue;

                    var propertyName = property.Name;
                    var propertyValue = property.GetValue(entity);

                    // إذا كانت الخاصية تحتوي على "En" أو "Ar" في اسمها
                    if (propertyName.EndsWith("En", StringComparison.OrdinalIgnoreCase) && lan == "en")
                    {
                        result["Name"] = propertyValue; // تحويل NameEn إلى Name
                    }
                    else if (propertyName.EndsWith("Ar", StringComparison.OrdinalIgnoreCase) && lan == "ar")
                    {
                        result["Name"] = propertyValue; // تحويل NameAr إلى Name
                    }
                    else
                    {
                        // إضافة الخصائص الأخرى كما هي ما عدا NameEn وNameAr
                        if (!propertyName.EndsWith("En", StringComparison.OrdinalIgnoreCase) &&
                            !propertyName.EndsWith("Ar", StringComparison.OrdinalIgnoreCase))
                        {
                            result[propertyName] = ProcessNestedProperty(propertyValue, lan);
                        }
                    }
                }

                return (object)result;
            });
        }

        private static IEnumerable<object> FilterProducts(IEnumerable<Product> products, string lan)
        {
            return products.Select(product =>
            {
                return new
                {
                    Id = product.Id,
                    Name = lan == "en" ? product.NameEn : product.NameAr,
                    Price = product.Price,
                    Variants = product.Variants?.Select(variant => new
                    {
                        Id = variant.Id,
                        Color = variant.Color,
                        Quantity = variant.QuantityInStock
                    }).ToList(),
                    Images = product.Images?.Select(image => new
                    {
                        Id = image.Id,
                        ImageUrl = image.ImageUrl
                    }).ToList()
                };
            });
        }

        private static object ProcessNestedProperty(object propertyValue, string lan)
        {
            if (propertyValue == null)
                return null;

            var propertyType = propertyValue.GetType();

            // إذا كانت الخاصية كائن متداخل (Nested Object)، نعالجها بشكل ديناميكي
            if (typeof(System.Collections.IEnumerable).IsAssignableFrom(propertyType) && propertyType != typeof(string))
            {
                var enumerable = (System.Collections.IEnumerable)propertyValue;
                var nestedResults = new List<object>();

                foreach (var item in enumerable)
                {
                    var nestedResult = FilterEntitiesByLanguage(new[] { item }, lan).FirstOrDefault();
                    nestedResults.Add(nestedResult);
                }

                return nestedResults;
            }

            // إذا كانت الخاصية ليست قائمة، نعيد معالجة الكائن الفردي
            return FilterEntitiesByLanguage(new[] { propertyValue }, lan).FirstOrDefault();
        }

        private static bool IsSimpleType(Type type)
        {
            return type.IsPrimitive ||
                   type == typeof(string) ||
                   type == typeof(decimal) ||
                   type == typeof(DateTime) ||
                   type.IsValueType;
        }
    }
}