using AutoMapper;
using WebAPI.Domain.DTOs.EmployeeDTOs;
using WebAPI.Domain.Models;

namespace WebAPI.Application.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() {
            CreateMap<Employee, ReadEmployeeDTO>()
                .ForMember(destino=> destino.NameEmployee, m=>m.MapFrom(origem=>origem.Name))
                .ForMember(destino=>destino.Company, m=>m.MapFrom(origem=>origem.CurrentCompany.Name));
            //Isso pq os campos Name e NameEmployee NÃO SÃO iguais!!!

            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<UpdateEmployeeDTO, Employee>();
        }
    }
}
