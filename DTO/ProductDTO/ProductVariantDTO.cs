﻿namespace Shoes_Ecommerce.DTO.ProductDTO
{
    public class ProductVariantDTO
    {
        public string colorHexCode { get; set; } = string.Empty;
        public int sizeValue { get; set; } = default!;
        public int QuantityInStock { get; set; }
    }
}
