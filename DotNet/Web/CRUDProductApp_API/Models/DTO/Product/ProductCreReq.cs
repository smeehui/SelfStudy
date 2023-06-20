using CRUDProductApp_API.Models.DTO.Category;

namespace CRUDProductApp_API.Models.DTO.Product
{
    public class ProductCreReq
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public CategoryCreReq Category { get; set; }
    }
}
