using AutoMapper;
using MicroServicio.Api.libro.Models;

namespace MicroServicio.Api.libro.Apps
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDto>();
        }
    }
}
