using AutoMapper;
using Core.Entities;
using DataAccess.DTO;

namespace DataAccess.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
