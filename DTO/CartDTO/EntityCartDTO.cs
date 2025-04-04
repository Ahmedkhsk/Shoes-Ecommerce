namespace Shoes_Ecommerce.DTO.CartDTO
{
    public class EntityCartDTO
    {
        public IEnumerable<object> products { get; set; }
        public double totalPrice { get; set; }
    }
}
