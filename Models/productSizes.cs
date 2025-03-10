namespace Shoes_Ecommerce.Models
{
    [Table("productSize")]
    public class productSize
    {
        [ForeignKey("Product"), Display(Name = "Product")]
        public int ProductID { get; set; }
        public Product Product { get; set; } = default!;
        public  double Size { get; set; }
        public int Stock { get; set; }

    }
}
