using CRUDProductApp_API.Data;
using CRUDProductApp_API.Models;
using CRUDProductApp_API.Models.DTO.Category;
using CRUDProductApp_API.Models.DTO.Product;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDProductApp_API.Controllers.APIs
{
    [Route("api/products")]
    [ApiController]
    public class ProductsAPI : ControllerBase
    {
        //private readonly ProductService _ProductService;
        private readonly AppDBContext _DbContext;



        public ProductsAPI(AppDBContext DbContext)
        {
            _DbContext = DbContext;
        }


        // GET: api/<ProductsAPI>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_DbContext.Products.Select(entity => new ProductRes
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                Category = new CategoryRes { Id = entity.Category.Id, Name = entity.Category.Name }
            }).ToList());
        }

        // GET api/<ProductsAPI>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Product? product = _DbContext.Products.Find();
            if (product != null)
            {
                return base.Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<ProductsAPI>
        [HttpPost]
        public IActionResult Post([FromBody] ProductCreReq productCreReq)
        {
            try
            {
                var Product = new Product
                {
                    Name = productCreReq.Name,
                    Price = productCreReq.Price,
                    Description = productCreReq.Description,

                };
                if (productCreReq.Category != null)
                {
                    Category? category = _DbContext.Categories.Find(productCreReq.Category.Id);
                    var cate = new Category();
                    if (category == null)
                    {
                        var newCate = new Category { Name = productCreReq.Category.Name };
                        cate = _DbContext.Categories.Add(newCate).Entity;
                        _DbContext.SaveChanges();
                    }
                    else
                    {
                        cate = category;
                    }
                    Product.Category = cate;
                }
                Product entity = _DbContext.Products.Add(Product).Entity;
                _DbContext.SaveChanges();
                return Ok(new ProductRes
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Price = entity.Price,
                    Description = entity.Description,
                    Category = new CategoryRes { Id = entity.Category.Id, Name = entity.Category.Name }
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<ProductsAPI>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProductUpReq ProductUpReq)
        {
            Product? product = _DbContext.Products.Find(id);
            if (product != null)
            {
                if (ProductUpReq.Name != null && !ProductUpReq.Name.Trim().Equals("")) product.Name = ProductUpReq.Name;
                if (ProductUpReq.Price != null) product.Price = (double)ProductUpReq.Price;
                if (ProductUpReq.Description != null && !ProductUpReq.Description.Trim().Equals("")) product.Description = ProductUpReq.Description;
                if (ProductUpReq.Category != null)
                {
                    Category? category = _DbContext.Categories.Find(ProductUpReq.Category.Id);
                    if (category == null)
                    {
                        var newCate = new Category { Name = ProductUpReq.Category.Name };
                        Category cate = _DbContext.Categories.Add(newCate).Entity;
                        _DbContext.SaveChanges();
                        product.Category = cate;
                    }
                    else
                    {
                        product.Category = category;
                    }
                }
                try
                {
                    Product entity = _DbContext.Products.Update(product).Entity;
                    _DbContext.SaveChanges();
                    return Ok(new ProductRes
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Price = entity.Price,
                        Description = entity.Description,
                        Category = new CategoryRes { Id = entity.Category.Id, Name = entity.Category.Name }
                    });
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<ProductsAPI>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product? product = _DbContext.Products.Find();
            if (product != null)
            {
                _DbContext.Products.Remove(product);
                _DbContext.SaveChanges();
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
