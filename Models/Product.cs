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
        public string sizeName { get; set; } = string.Empty;
        public DateTime productDate { get; set; }
        public int productSellers { get; set; }
        public ICollection<productSize> productSizes { get; set; } = new List<productSize>();
        public ICollection<productImage> productImages { get; set; } = new List<productImage>();

        [ForeignKey("Category"),Display(Name = "Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; } = default!;
    }
}
