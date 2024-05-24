using AutoMapper;
using Core.Entities;
using Core.DTO;

namespace Core.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, EmployeeCreateUpdateDTO>().ReverseMap();
        }
    }
}
