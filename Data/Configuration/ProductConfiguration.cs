using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shoes_Ecommerce.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(p => p.productDate)
                  .HasDatabaseName("IX_Product_Date");

            builder.HasIndex(p => p.productSellers)
                  .HasDatabaseName("IX_Product_Sellers");

            builder.HasIndex(p => p.CategoryID)
                  .HasDatabaseName("IX_Product_Category");
        }
    }
}
