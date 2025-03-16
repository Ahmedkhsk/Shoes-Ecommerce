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
    }


}
