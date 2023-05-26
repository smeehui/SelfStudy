using Microsoft.AspNetCore.Mvc;
using ProductCRUD_RepoPattern.Model.DTO;
using ProductCRUD_RepoPattern.Repository.CategoryRepository;
using ProductCRUD_RepoPattern.Repository.ProductRepository;
using ProuctCRUD_RepoPattern.Model;

namespace ProductCRUD_RepoPattern.Controllers.API
{
    [Route("api/products")]
    [ApiController]
    public class ProductsAPI : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductsAPI(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: api/ProductsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            return Ok(_productRepository.GetAll());
        }

        // GET: api/ProductsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            return Ok(_productRepository.GetById(id));
        }

        // PUT: api/ProductsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutProduct(Guid id, ProductDTO product)
        {
            return Ok(_productRepository.Update(id,product));
        }

        // POST: api/ProductsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostProduct(ProductDTO product)
        {
            if (product.Category != null)
            {
                CategoryDTO? category = _categoryRepository.GetByName(product.Category.Name);
                if (category == null)
                {
                    product.Category = _categoryRepository.Add(product.Category);
                }
            };
            product = _productRepository.Add(product);
            return Ok(product);
        }

        //// DELETE: api/ProductsAPI/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(Guid id)
        //{
        //    if (_productRepository.Products == null)
        //    {
        //        return NotFound();
        //    }
        //    var product = await _productRepository.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    _productRepository.Products.Remove(product);
        //    await _productRepository.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ProductExists(Guid id)
        //{
        //    return (_productRepository.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
