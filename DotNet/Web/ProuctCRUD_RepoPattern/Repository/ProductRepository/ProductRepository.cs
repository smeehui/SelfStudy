using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductCRUD_RepoPattern.DB;
using ProductCRUD_RepoPattern.Model.DTO;
using ProductCRUD_RepoPattern.Repository.CategoryRepository;
using ProuctCRUD_RepoPattern.Model;

namespace ProductCRUD_RepoPattern.Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public ProductRepository(AppDBContext context, IMapper mapper,ICategoryRepository categoryRepository)
        {
            _context = context;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public ProductDTO Add(ProductDTO dto)
        {
            try
            {
                Product newEntity = _mapper.Map<Product>(dto);
                _context.Entry(newEntity).State = EntityState.Modified;
                //_context.Products.Attach(newEntity);
                Product entity = _context.Products.Add(newEntity).Entity;
                _context.SaveChanges();
                return _mapper.Map<ProductDTO>(entity);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public List<ProductDTO> GetAll()
        {
            List<Product> products = _context.Products.Include(p => p.Category).ToList();
            List<ProductDTO> dtoList = new();
            foreach (var item in products)
            {
                dtoList.Add(_mapper.Map<ProductDTO>(item));
            }
            return dtoList;
        }

        public ProductDTO? GetById(Guid id)
        {
            Product? product = _context.Products.Where(s => s.Id.Equals(id)).Include(p => p.Category).FirstOrDefault();
            if (product == null) { return null; }
            return _mapper.Map<ProductDTO>(product);
        }

        public void Remove(Guid id)
        {
            Product? product = _context.Products.Where(s => s.Id.Equals(id)).FirstOrDefault();

            if (product != null)
            {
                _context.Products.Remove(product);
            }
            else
            {
                throw new DbUpdateException();
            }
        }

        public ProductDTO Update(Guid id, ProductDTO dto)
        {
            Product? product = _context.Products.Where(p => p.Id == id).Include(p => p.Category).FirstOrDefault();

            if (product != null)
            {
                var NewProduct = _mapper.Map(dto, product);

                if (dto.Category!=null)
                {
                    Category? category = null;
                    if (dto.Category.Id!=Guid.Empty)
                    {
                        category = _categoryRepository.findById(dto.Category.Id);
                    }else if (dto.Category.Name!=null)
                    {
                        category = _categoryRepository.findByName(dto.Category.Name);
                    }
                    if (category != null)
                    {
                        NewProduct.Category = category;
                    }
                    else
                    {
                        _categoryRepository.Add(dto.Category);
                    }
                }
                var updatedProduct = _context.Products.Update(NewProduct).Entity;
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
                return _mapper.Map<ProductDTO>(updatedProduct);
            }
            else
            {
                throw new DbUpdateException();
            }
        }
    }
}
