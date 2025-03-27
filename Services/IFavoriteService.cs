

namespace Shoes_Ecommerce.Services
{
    public interface IFavoriteService
    {
        public Task AddFavoriteAsync(FavoriteAddDTO favoriteDTO);
        public Task RemoveFavoriteAsync(FavoriteAddDTO favoriteDTO);
        public Task<List<FavoriteGetDTO>> GetFavoriteAsync(FavoriteGetDTO favoriteGetDTO);
    }
}
