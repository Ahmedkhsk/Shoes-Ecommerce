
namespace Shoes_Ecommerce.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<ApplicationUser> userRepo;
        private readonly IGenericRepository<Favorite> favRepo;

        public FavoriteService(IGenericRepository<Product> productRepo , 
            IGenericRepository<ApplicationUser> userRepo ,
            IGenericRepository<Favorite> favRepo)
        {
            this.productRepo = productRepo;
            this.userRepo = userRepo;
            this.favRepo = favRepo;
        }

        public async Task AddFavoriteAsync(FavoriteAddDTO favoriteDTO)
        {
            var user = await userRepo.GetByIdAsync(favoriteDTO.userId);
            var product = await productRepo.GetByIdAsync(favoriteDTO.productId);
            
            //Check لو هما موجودين في الداتا بيز
            
            if (user != null && product != null)
            {
                await favRepo.AddAsync(new Favorite
                {
                    productId = favoriteDTO.productId,
                    userId = favoriteDTO.userId
                });

                await favRepo.Save();
            }
        }

        public List<Product> GetFavorites(string id)
        {
            List<Product> products = favRepo.GetProductsFavorite(id);
            return products;
        }

        public async Task RemoveFavoriteAsync(FavoriteAddDTO favoriteDTO)
        {
            var user = await userRepo.GetByIdAsync(favoriteDTO.userId);
            var product = await productRepo.GetByIdAsync(favoriteDTO.productId);

            if (user != null && product != null)
            {
                var facorite = favRepo.GetAllAsync().Result.FirstOrDefault(f => f.userId == favoriteDTO.userId && f.productId == favoriteDTO.productId);
                if (facorite != null)
                {
                    await favRepo.DeleteAsync(facorite.Id);
                }
                await favRepo.Save();
            }
        }
    }
}
