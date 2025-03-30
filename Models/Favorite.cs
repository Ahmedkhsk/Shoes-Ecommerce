namespace Shoes_Ecommerce.Models
{
    [Table("Favorite")]
    public class Favorite
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public Product Product { get; set; } = default!;
        public string userId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = default!;
    }
}
