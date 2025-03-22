namespace Shoes_Ecommerce.Helpers.Localization
{
    public static class EntityHelper
    {
        public static IEnumerable<object> FilterEntitiesByLanguage<T>(IEnumerable<T> entities, string lan)
        {
            if (typeof(T) == typeof(Product))
            {
                return FilterProducts(entities.Cast<Product>(), lan);
            }

            return entities.Select(entity =>
            {
                var entityType = entity.GetType();
                var properties = entityType.GetProperties();

                var result = new Dictionary<string, object>();

                foreach (var property in properties)
                {
                    if (property.GetIndexParameters().Length > 0 || !property.CanRead) 
                        continue;

                    var propertyName = property.Name;
                    var propertyValue = property.GetValue(entity);

                    if (propertyName.EndsWith("En", StringComparison.OrdinalIgnoreCase) && lan == "en")
                    {
                        result["name"] = propertyValue;
                    }
                    else if (propertyName.EndsWith("Ar", StringComparison.OrdinalIgnoreCase) && lan == "ar")
                    {
                        result["name"] = propertyValue;
                    }
                    else
                    {
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
                    id = product.Id,
                    name = lan == "en" ? product.NameEn : product.NameAr,
                    price = product.Price,
                    discount = product.discount,
                    description = lan == "en" ? product.descriptionEn : product.descriptionAr,
                    productdate = product.productDate,
                    productsellers = product.productSellers,
                    Variants = product.Variants?.Select(variant => new
                    {
                        colorid = variant.ColorId,
                        color = variant.Color,
                        Quantity = variant.QuantityInStock
                    }).ToList(),
                    Images = product.Images?.Select(image => new
                    {
                        imageurl = image.ImageUrl
                    }).ToList()
                };
            });
        }

        private static object ProcessNestedProperty(object propertyValue, string lan)
        {
            if (propertyValue == null)
                return null;

            var propertyType = propertyValue.GetType();

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

            return FilterEntitiesByLanguage(new[] { propertyValue }, lan).FirstOrDefault();
        }
    }
}