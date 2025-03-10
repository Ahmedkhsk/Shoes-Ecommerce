namespace Shoes_Ecommerce.Models
{
    [Table("productImage")]
    public class productImage
    {
        [ForeignKey("Product"),Display(Name = "Product")]
        public int ProductID { get; set; }
        public Product Product { get; set; } = default!;
        public string ImageName { get; set; } = string.Empty;
    }
}
