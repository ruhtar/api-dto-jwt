using AutoMapper;
using WebAPI.Domain.DTOs;
using WebAPI.Domain.Models;

namespace WebAPI.Application.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(destino=> destino.NameEmployee, m=>m.MapFrom(origem=>origem.Name));
            //Isso pq os campos Name e NameEmployee NÃO SÃO iguais!!!
        }
    }
}
