namespace Shoes_Ecommerce.Helpers.Notificaciones
{
    public static class SendNotificaciones
    {
        public static async Task SendNotificationAsync(string token, string title, string body)
        {
            var message = new Message()
            {
                Token = token,
                Notification = new Notification()
                {
                    Title = title,
                    Body = body
                }
            };

            var response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            Console.WriteLine($"Notification sent successfully: {response}");
        }
        public static async Task SendMulticastNotificationAsync(List<string> tokens, string title, string body)
        {
            var message = new MulticastMessage()
            {
                Tokens = tokens,
                Notification = new Notification()
                {
                    Title = title,
                    Body = body
                }
            };

            var response = await FirebaseMessaging.DefaultInstance.SendEachForMulticastAsync(message);
            Console.WriteLine($"Successfully sent {response.SuccessCount} messages");
        }
    }
}
