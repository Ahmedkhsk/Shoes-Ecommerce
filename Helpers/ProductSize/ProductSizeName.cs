namespace Shoes_Ecommerce.Helpers.ProductSize
{
    public static class ProductSizeName
    {
        public static string GetSizeName(int sizeValue)
        {
            if (sizeValue > 33 && sizeValue < 38)
                return "LL";
            else if (sizeValue > 39 && sizeValue < 45)
                return "RR";

            return "ErrorSize";
        }
    }
}
