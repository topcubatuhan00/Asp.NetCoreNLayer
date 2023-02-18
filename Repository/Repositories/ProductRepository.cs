using Core.Models;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            return await _appDbContext.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
