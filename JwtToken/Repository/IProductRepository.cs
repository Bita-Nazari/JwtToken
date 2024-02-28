using JwtToken.Model;

namespace JwtToken.Repository
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAll();
    }
}
