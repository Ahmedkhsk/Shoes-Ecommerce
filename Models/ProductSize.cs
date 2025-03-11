namespace Shoes_Ecommerce.Models
{
    [Table("ProductSize")]
    public class ProductSize
    {
        public int Id { get; set; }
        public string sizeName { get; set; } = string.Empty;
        public int SizeValue { get; set; } 

    }
}
