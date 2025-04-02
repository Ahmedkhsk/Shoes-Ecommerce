namespace Shoes_Ecommerce.DTO.CartDTO
{
    public class GetCartDTO
    {

        public List<getProductsOfCart> products { get; set; } = new List<getProductsOfCart>();
        public double totalPrice { get; set; }
    }
}
