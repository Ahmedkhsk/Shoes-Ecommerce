using System.Drawing;

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
            else if(typeof(T) == typeof(Category))
            {
                return FilterCategories(entities.Cast<Category>(), lan);
            }
            return default!;
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
                    productDate = product.productDate,
                    productSellers = product.productSellers,
                    variants = product.Variants?.Select(variant => new
                    {
                        id = variant.Id,
                        colorId = variant.ColorId,
                        color = variant.Color,
                        sizeValue = variant.Size.SizeValue,
                        sizeName = variant.Size.sizeName,
                        quantity = variant.QuantityInStock
                    }).ToList(),
                    images = product.Images?.Select(image => new
                    {
                        imageUrl = image.ImageUrl
                    }).ToList()
                };
            });
        }
        

        private static IEnumerable<object> FilterCategories(IEnumerable<Category> categories, string lan)
        {
            return categories.Select(category =>
            {
                return new
                {
                    id = category.Id,
                    name = lan == "en" ? category.NameEn : category.NameAr,
                    imageUrl = category.ImageUrl
                };
            });
        }
    }
}