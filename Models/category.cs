namespace Shoes_Ecommerce.Models
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
