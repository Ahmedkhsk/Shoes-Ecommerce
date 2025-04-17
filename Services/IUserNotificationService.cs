namespace Shoes_Ecommerce.Services
{
    public interface IUserNotificationService
    {
        Task<List<UserNotification>> GetUserNotificationsAsync(string userId);
    }
}
