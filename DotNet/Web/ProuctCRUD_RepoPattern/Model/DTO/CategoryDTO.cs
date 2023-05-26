using AutoMapper;
using ProuctCRUD_RepoPattern.Model;

namespace ProductCRUD_RepoPattern.Model.DTO
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
