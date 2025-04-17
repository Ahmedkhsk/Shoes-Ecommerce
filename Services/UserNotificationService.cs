namespace Shoes_Ecommerce.Services
{
    public class UserNotificationService : IUserNotificationService
    {
        private readonly IUserNotificationService userNotificationService;

        public UserNotificationService(IUserNotificationService userNotificationService)
        {
            this.userNotificationService = userNotificationService;
        }
        public async Task<List<UserNotification>> GetUserNotificationsAsync(string userId)
        {
            return await userNotificationService.GetUserNotificationsAsync(userId);
        }
    }
}
