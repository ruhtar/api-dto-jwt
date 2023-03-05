using AutoMapper;
using WebAPI.Domain.DTOs.CompanyDTOs;
using WebAPI.Domain.Models;

namespace WebAPI.Application.Mapping
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile() {
            CreateMap<Company, ReadCompanyDTO>();
        }
    }
}
