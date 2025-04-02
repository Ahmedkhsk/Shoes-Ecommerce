
using Shoes_Ecommerce.Models;
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
            else if(typeof(T) == typeof(GetCartDTO))
            {
                return FilterProductInCart(entities.Cast<getProductsOfCart>(),lan);
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
                    targetGender = product.targetGender,
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

        public static GetCartDTO FilterCart(GetCartDTO cart, string lan)
        {
            return new GetCartDTO
            {
                
                products = cart.products.Select(p => new getProductsOfCart
                {
                    productId = p.productId,
                    productNameEn = lan == "en" ? p.productNameEn : "",
                    productNameAr = lan == "Ar" ? p.productNameAr : "",
                    productSizeName = p.productSizeName,
                    price = p.price,
                    imageName = p.imageName,
                    quantity = p.quantity
                }).ToList(),
               
                totalPrice = cart.totalPrice
            };
        }
        private static IEnumerable<object> FilterProductInCart(IEnumerable<getProductsOfCart> products, string lan)
        {
            return products.Select(p =>
            {
                return new
                {
                    ProductId = p.productId,
                    Name = lan == "en" ? p.productNameEn : p.productNameAr,
                    Size = p.productSizeName,
                    Price = p.price,
                    Image = p.imageName,
                    Quantity = p.quantity
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