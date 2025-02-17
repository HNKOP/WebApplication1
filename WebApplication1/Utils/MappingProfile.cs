using AutoMapper;
using WebApplication1.Entities;

namespace WebApplication1.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<DataEntityDto, DataEntity>();
        }
    }
}
