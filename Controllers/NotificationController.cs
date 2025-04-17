using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom.Compiler;

namespace Shoes_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IUserNotificationService userNotificationService;

        public NotificationController(IUserNotificationService userNotificationService)
        {
            this.userNotificationService = userNotificationService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetUserNotifications(string userId ,string lan = "en")
        { 
            var notifications = await userNotificationService.GetUserNotificationsAsync(userId);

            if (notifications == null || !notifications.Any())
            {
                return BadRequest(new ApiResponse(false,LocalizationHelper.GetLocalizedMessage("NoNotificationsFound",lan)));
            }
            return Ok(new ApiResponse(true,LocalizationHelper.GetLocalizedMessage("NotificationsRetrived",lan), notifications));
        }
    }
}
