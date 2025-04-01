namespace Shoes_Ecommerce.Helpers.Images
{
    public static class Images
    {
        public static async Task<string> SaveImage(IFormFile Image, string ImagePath)
        {
            var ImageName = $"{Guid.NewGuid()}{Path.GetExtension(Image.FileName)}";
            var path = Path.Combine(ImagePath, ImageName);

            using var stream = File.Create(path);
            await Image.CopyToAsync(stream);
           
            return ImageName;
        }
        public static void DeleteImage(string imageName , string imagePath)
        {
            var imageUrl = Path.Combine(imagePath, imageName);
            
            if (File.Exists(imageUrl))
                File.Delete(imageUrl);
        }
        
    }


}
