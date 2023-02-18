using Core.Models;

namespace Core.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetSingleCategoryByIdWithProductAsync(int categoryId);

    }
}
