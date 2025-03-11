namespace Shoes_Ecommerce.Models
{
    [Table("ProductVariant")]
    public class ProductVariant
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;

        public int ColorId { get; set; }
        public ProductColor Color { get; set; } = default!;

        public int SizeId { get; set; }
        public ProductSize Size { get; set; } = default!;

        public int QuantityInStock { get; set; }

    }
}
