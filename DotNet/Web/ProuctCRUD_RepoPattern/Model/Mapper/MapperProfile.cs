using AutoMapper;
using ProductCRUD_RepoPattern.Model.DTO;
using ProuctCRUD_RepoPattern.Model;
using System.Diagnostics;

namespace ProductCRUD_RepoPattern.Model.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<double?, double>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<ProductDTO, Product>()
                .ForAllMembers(
                    opt => opt.Condition((src, dest, srcVl, destVl) =>
                    {
                        if (srcVl != null && srcVl.GetType().Equals(typeof(Guid)))
                        {
                            return !srcVl.Equals(Guid.Empty);
                        }
                        return srcVl != null;
                    }));
            CreateMap<Product, ProductDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
