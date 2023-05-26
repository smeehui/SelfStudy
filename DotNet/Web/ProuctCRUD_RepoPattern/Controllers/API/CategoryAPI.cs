using Microsoft.AspNetCore.Mvc;
using ProductCRUD_RepoPattern.Repository.CategoryRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductCRUD_RepoPattern.Controllers.API
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryAPI : ControllerBase
    {
        private ICategoryRepository _categoryRepository;

        public CategoryAPI(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/<CategoryAPI>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoryRepository.GetAll());
        }

        // GET api/<CategoryAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryAPI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
