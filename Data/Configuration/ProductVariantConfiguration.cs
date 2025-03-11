namespace Shoes_Ecommerce.Data.Configuration
{
    public class ProductVariantConfiguration
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.HasIndex(pv => new { pv.ProductId, pv.ColorId, pv.SizeId })
                  .IsUnique()
                  .HasDatabaseName("IX_ProductVariant_UniqueCombination");
           
            builder.HasIndex(pv => pv.QuantityInStock)
                  .HasDatabaseName("IX_ProductVariant_Stock");
        }
    }
}
