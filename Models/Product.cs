namespace Shoes_Ecommerce.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public string NameEn { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public double Price { get; set; }
        public double discount { get; set; }
        public string descriptionEn { get; set; } = string.Empty;
        public string descriptionAr { get; set; } = string.Empty;
        public DateTime productDate { get; set; } = DateTime.Now;
        public int productSellers { get; set; }
        public ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public int CategoryID { get; set; }
        public Category Category { get; set; } = default!;
    }
}
