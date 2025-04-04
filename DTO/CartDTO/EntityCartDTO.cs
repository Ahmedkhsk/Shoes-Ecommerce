namespace Shoes_Ecommerce.DTO.CartDTO
{
    public class EntityCartDTO
    {
        public IEnumerable<object> products { get; set; }
        public double totalPrice { get; set; }
        public double subPrice { get; set; }
        public double shoppingPrice { get; set; }
    }
}
