using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Infra.Repositories.CompanyRepository;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("company")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(CompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCompanyById([FromRoute] int id) {
            var company = _companyRepository.GetCompany(id);
            if (company == null) return NotFound("Company not found.");
            return Ok(company);
        }
    }
}
