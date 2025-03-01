namespace Shoes_Ecommerce.DTO
{
    public class ApiResponse
    {
        public bool Succes { get; set; }
        public string? Message { get; set; }
        public dynamic Data { get; set; }

        public ApiResponse(bool Succes, string Message = default!, dynamic Data = default!)
        {
            this.Succes = Succes;
            this.Message = Message;
            this.Data = Data;
        }
    }
}
