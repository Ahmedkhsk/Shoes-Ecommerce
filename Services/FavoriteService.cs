﻿namespace Shoes_Ecommerce.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IProductRepository productRepo;
        private readonly IGenericRepository<ApplicationUser> userRepo;
        private readonly IGenericRepository<Favorite> favRepo;

        public FavoriteService(IProductRepository productRepo , 
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

            var favorite = favRepo.GetAllAsync().Result.FirstOrDefault(f => f.userId == favoriteDTO.userId && f.productId == favoriteDTO.productId);
            
            if (favorite == null)
            {
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
        }
        public async Task UpdateFavoriteAsync(FavoriteAddDTO favoriteDTO)
        {
            var user = await userRepo.GetByIdAsync(favoriteDTO.userId);
            var product = await productRepo.GetByIdAsync(favoriteDTO.productId);
            if (user != null && product != null)
            {
                var favorite = favRepo.GetAllAsync().Result.FirstOrDefault(f => f.userId == favoriteDTO.userId && f.productId == favoriteDTO.productId);

                if (favorite != null)
                {
                    favorite.productId = favoriteDTO.productId;
                    favRepo.Update(favorite);
                    await favRepo.Save();
                }
            }
        }
        public async Task RemoveFavoriteAsync(FavoriteAddDTO favoriteDTO)
        {
            var user = await userRepo.GetByIdAsync(favoriteDTO.userId);
            var product = await productRepo.GetByIdAsync(favoriteDTO.productId);

            if (user != null && product != null)
            {
                var favorite = favRepo.GetAllAsync().Result.FirstOrDefault(f => f.userId == favoriteDTO.userId && f.productId == favoriteDTO.productId);
                
                if (favorite != null)
                    await favRepo.DeleteAsync(favorite.Id);
                
                await favRepo.Save();
            }
        }
        public List<Product> GetFavorites(string id)
        {
            List<Product> products = productRepo.GetProductsByUserIDInFavorite(id);
            return products;
        }

    }
}
