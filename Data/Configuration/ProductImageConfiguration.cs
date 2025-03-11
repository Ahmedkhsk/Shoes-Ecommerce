using Shoes_Ecommerce.Models;

namespace Shoes_Ecommerce.Data.Configuration
{
    public class ProductImageConfiguration
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasIndex(pi => pi.ProductID)
                  .HasDatabaseName("IX_ProductImage_Product");
        }
    }
}
