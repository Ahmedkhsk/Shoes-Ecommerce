
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
            
            if (user != null && product != null)
            {
                favRepo?.AddAsync(new Favorite
                {
                    productId = favoriteDTO.productId,
                    userId = favoriteDTO.userId
                });
            }
        }

        public Task<List<Product>> GetFavoriteAsync(FavoriteGetDTO favoriteGetDTO)
        {
            List<Product> products = new List<Product>();
        }

        public Task RemoveFavoriteAsync(FavoriteAddDTO favoriteDTO)
        {
            throw new NotImplementedException();
        }
    }
}
