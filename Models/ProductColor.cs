namespace Shoes_Ecommerce.Models
{
    [Table("ProductColor")]
    public class ProductColor
    {
        public int Id { get; set; }
        public string hexCode { get; set; } = string.Empty;
    }
}
