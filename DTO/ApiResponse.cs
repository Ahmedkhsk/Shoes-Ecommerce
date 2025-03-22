namespace Shoes_Ecommerce.DTO
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public dynamic Data { get; set; }

        public ApiResponse(bool Success, string Message = default!, dynamic Data = default!)
        {
            this.Success = Success;
            this.Message = Message;
            this.Data = Data;
        }
    }
}
