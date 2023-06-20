
using AutoMapper;
using ProuctCRUD_RepoPattern.Model;

namespace ProductCRUD_RepoPattern.Model.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public CategoryDTO? Category { get; set; }
    }
}
