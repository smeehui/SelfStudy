using AutoMapper;
using AutoMapperPractice.Model;
using AutoMapperPractice.Model.DTO;
using AutoMapperPractice.Utils;

namespace AutoMapperPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Product(1, "IPX", "New", 1000);
            var p2 = new Product(1, "IPXs", "New", 1000);
            var p3 = new Product(1, "IPXt", "New", 1000);
            var p4 = new Product(1, "IPXr", "New", 1000);
            List<Product> products = new(new Product[] {p1,p2,p3,p4});
            //foreach (var item in new ModelMapper<ProductCreReq,Product>().ToDTOList<ProductRes>(products))
            //{
            //    Console.WriteLine(item);
            //};
            var pcr = new ProductCreReq("ipY", "Old", 10000);
            Console.WriteLine(new ModelMapper<ProductCreReq, Product>().TransferFields(pcr));

            //Utils.ModelMapper<ProductCreReq, Product> mapper = new();
            //Product product = mapper.ToEntity(pcr);
            //MapperConfiguration config = new MapperConfiguration(cfg=>cfg.CreateMap<Product, ProductRes>());
            //Mapper mapper1 = new(config);

            //ProductRes value = mapper1.Map<Product, ProductRes>(p1);
            //Console.WriteLine(ModelMapper.ToEntity<ProductCreReq,Product>(pcr));

        }
    }
}