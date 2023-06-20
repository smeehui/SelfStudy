using AutoMapper;

namespace CRUDProductApp_API.Utils
{
    public class ModelMapper<Entity, ReqDTO, ResDTO>
    {


        private readonly Mapper _ReqMapper;
        private readonly Mapper _ResMapper;
        public ModelMapper()
        {
            var ReqConfig = new MapperConfiguration(cfg => cfg.CreateMap<Entity, ReqDTO>());
            var ResConfig = new MapperConfiguration(cfg => cfg.CreateMap<Entity, ResDTO>());

            _ReqMapper = new Mapper(ReqConfig);
            _ResMapper = new Mapper(ResConfig);
        }
        public Entity ToEntity(ReqDTO dto)
        {
            return _ReqMapper.Map<ReqDTO, Entity>(dto);
        }
        public Entity ToEntity(ResDTO dto)
        {
            return _ReqMapper.Map<ResDTO, Entity>(dto);
        }
        public ReqDTO ToReqDTO(Entity entity)
        {
            return _ReqMapper.Map<Entity, ReqDTO>(entity);
        }
        public ResDTO ToResDTO(Entity entity)
        {
            return _ResMapper.Map<Entity, ResDTO>(entity);
        }
    }
}
