namespace Shoes_Ecommerce.Models
{
    [Table("ProductImage")]
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; } = default!;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
