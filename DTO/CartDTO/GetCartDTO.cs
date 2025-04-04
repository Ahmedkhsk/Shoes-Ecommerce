namespace Shoes_Ecommerce.DTO.CartDTO
{
    public class GetCartDTO
    {

        public List<getProductsOfCart> products { get; set; } = new List<getProductsOfCart>();
        public double subPrice { get; set; }
        public double shoppingPrice { get; set; } = 50;
        public double totalPrice { get; set; }
    }
}
