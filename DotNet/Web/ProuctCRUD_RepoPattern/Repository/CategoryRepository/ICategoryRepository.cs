using ProductCRUD_RepoPattern.Model.DTO;
using ProuctCRUD_RepoPattern.Model;

namespace ProductCRUD_RepoPattern.Repository.CategoryRepository
{
    public interface ICategoryRepository : IGeneralRepository<CategoryDTO>
    {
        public CategoryDTO? GetByName(string Name);
        public Category? findByName(string Name);
        public Category? findById(Guid id);
    }
}
