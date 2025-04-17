namespace Shoes_Ecommerce.Helpers.Notificaciones
{
    public static class SendNotificaciones
    {
        public static async Task SendProductNotificationToTopic(string topic, string title, string body)
        {
            var serverKey = "YOUR_FIREBASE_SERVER_KEY";
            var client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"key={serverKey}");

            var message = new
            {
                to = $"/topics/{topic}",
                notification = new
                {
                    title = title,
                    body = body,
                }
                //data = new
                //{
                //    productId = product.Id.ToString(),
                //    productName = product.NameEn,
                //    productImage = product.Images,
                //    productPrice = product.Price
                //}
            };

            var jsonMessage = JsonConvert.SerializeObject(message);
            var content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

            var result = await client.PostAsync("https://fcm.googleapis.com/v1/projects/shoes-app-cdf3b/messages:send", content);

            var response = await result.Content.ReadAsStringAsync();
            Console.WriteLine($"Firebase Response: {response}");
        }

    }
}
