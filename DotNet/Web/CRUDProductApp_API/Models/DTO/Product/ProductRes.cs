using CRUDProductApp_API.Models.DTO.Category;

namespace CRUDProductApp_API.Models.DTO.Product
{
    public class ProductRes
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public CategoryRes Category { get; set; }
    }
}
