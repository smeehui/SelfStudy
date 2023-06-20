using AutoMapper;
using ProductCRUD_RepoPattern.DB;
using ProductCRUD_RepoPattern.Model.DTO;
using ProuctCRUD_RepoPattern.Model;

namespace ProductCRUD_RepoPattern.Repository.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<CategoryDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public CategoryDTO? GetById(Guid id)
        {
            Category? category = findById(id);
            if (category != null)
            {
                return _mapper.Map<CategoryDTO>(category);
            }
            return null;
        }
        public CategoryDTO? GetByName(string Name)
        {
            Category? category = findByName(Name);
            if (category != null)
            {
                return _mapper.Map<CategoryDTO>(category);
            }
            return null;
        }
        public CategoryDTO Add(CategoryDTO dto)
        {
            Category category = _mapper.Map<Category>(dto);
            Category entity = _context.Categories.Add(category).Entity;
            return _mapper.Map<CategoryDTO>(entity);
        }


        public void Remove(Guid guid)
        {
            throw new NotImplementedException();
        }

        public CategoryDTO Update(Guid id, CategoryDTO entity)
        {
            throw new NotImplementedException();
        }

        public Category findByName(string Name)
        {
            Category? category = _context.Categories.Where(c => c.Name == Name).FirstOrDefault();
            if (category != null)
            {
                return category;
            }
            return null;
        }

        public Category findById(Guid id)
        {
            Category? category = _context.Categories.Find(id);
            if (category != null)
            {
                return category;
            }
            return null;
        }
    }
}
