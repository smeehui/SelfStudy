using AutoMapper;

namespace AutoMapperPractice.Utils
{
    internal class ModelMapper<TSource, TDestination>
    {
        protected Mapper _mapper;

        public ModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            _mapper = new Mapper(config);
        }
        public TDestination ToEntity(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
        public TDestination TransferFields<Source>(Source source)
        {
            return new Mapper(new MapperConfiguration(cfg=>cfg.CreateMap<Source,TDestination>())).Map<Source, TDestination>(source);
        }
        public DTO ToDTO<DTO>(TDestination source)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, DTO>());
            return new Mapper(config).Map<DTO>(source);
        }
        public List<DTO> ToDTOList<DTO>(List<TDestination> sourceList)
        {
            List<DTO> result = new();
            foreach (var source in sourceList)
            {
                result.Add(new Mapper(new MapperConfiguration(cfg=>cfg.CreateMap<TDestination,DTO>())).Map<DTO>(source));
            }
            return result;
        }
    }
}
