using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.DTOs;
using WebAPI.Domain.Models;
using WebAPI.Infra.Repositories.CompanyRepository;
using WebAPI.Infra.Repositories.EmployeeRepository;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ILogger<EmployeeController> _logger; 
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository repository, ILogger<EmployeeController> logger, IMapper mapper, ICompanyRepository companyRepository)
        {
            _employeeRepository = repository;
            _logger = logger;
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetEmployees()
        {
            var employees = _employeeRepository.GetEmployees();

            return Ok(employees);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployeeById([FromRoute] int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            return Ok(_mapper.Map<EmployeeDTO>(employee));
        }


        [HttpPost]
        [Route("register")]
        public IActionResult RegisterEmployee([FromBody] EmployeeViewModel employeeViewModel)
        {
            //Funciona passa as infos dele e o id da empresa. 
            var company = _companyRepository.GetCompanyById(employeeViewModel.CurrentCompanyId);
            var employee = new Employee(employeeViewModel.Name, employeeViewModel.Age, null, company);
            var isSucced = _employeeRepository.Add(employee);
            if (isSucced) return Created("", employee);
            return BadRequest("Incorrect parameters.");
        }




    }
}
