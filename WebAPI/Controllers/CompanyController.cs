using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.DTOs;
using WebAPI.Domain.DTOs.CompanyDTOs;
using WebAPI.Domain.Models;
using WebAPI.Infra.Repositories.CompanyRepositoryName;
using WebAPI.ViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("company")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCompanyById([FromRoute] int id) {
            var company = _companyRepository.GetCompanyById(id);
            return company == null ? NotFound("Company not found.") : Ok(company);   
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetCompanies()
        {
            var companies = _companyRepository.GetCompanies();
            var companiesDTO = new List<ReadCompanyDTO>();
            foreach (var item in companies)
            {
                companiesDTO.Add(_mapper.Map<ReadCompanyDTO>(item));
            }
            return Ok(companiesDTO);
        }

        [HttpPost]
        [Route("/register")]
        public IActionResult RegisterCompany([FromBody] CompanyViewModel company)
        {
            var newCompany = new Company() { 
                Name= company.Name,
                Address = company.Address,
            };
            var isSucced = _companyRepository.Add(newCompany);
            if(isSucced) return Created("", newCompany);
            return BadRequest("Incorrect parameters.");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCompany([FromRoute] int id)
        {
            bool isSucceded = _companyRepository.DeleteCompany(id);
            if(isSucceded) return Ok("Company deleted.");
            return NotFound();
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateCompany([FromRoute] int id, [FromBody] CompanyViewModel model)
        {
            bool isSucceded = _companyRepository.UpdateCompany(id, model);
            if (isSucceded) return Ok("Company status updated.");
            return NotFound();
        }
    }
}
