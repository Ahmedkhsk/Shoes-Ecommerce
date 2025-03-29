using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoes_Ecommerce.DTO.NotificationDTO;

namespace Shoes_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        [HttpPost("send-one")]
        public async Task<IActionResult> SendNotification(NotificationDTO request)
        {
            await SendNotificaciones.SendNotificationAsync(request.Token, request.Title, request.Body);
            return Ok(new ApiResponse(true, "Notification sent successfully"));
        }

        [HttpPost("send-multiple")]
        public async Task<IActionResult> SendMulticastNotification(MulticastNotificationDTO request)
        {
            await SendNotificaciones.SendMulticastNotificationAsync(request.Tokens, request.Title, request.Body);
            return Ok(new ApiResponse(true, "Notifications sent successfully"));
        }
    }
}
