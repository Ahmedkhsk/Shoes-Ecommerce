namespace Shoes_Ecommerce.Models
{
    public class Cart
    {
        public  int  id { get; set; }

        [ForeignKey("user")]
        public string userId { get; set; } = default!;
        public ApplicationUser user { get; set; } = default!;
        
        [ForeignKey("product")]        
        public int productId { get; set; }
        public Product product { get; set; } = default!;

        [ForeignKey("variant")]
        public int variantId { get; set; }
        public ProductVariant variant { get; set; } = default!;
        public int quantity { get; set; }     
    }
}
