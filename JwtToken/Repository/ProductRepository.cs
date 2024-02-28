using JwtToken.Model;

namespace JwtToken.Repository
{
    public class ProductRepository : IProductRepository
    {
        ApplicationContext _context;
        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAll()
        {
            var products =  _context.Products.ToList();
            return products;
        }
    }
}
