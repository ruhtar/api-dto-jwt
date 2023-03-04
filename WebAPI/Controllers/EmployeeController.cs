using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAPI.Domain.DTOs;
using WebAPI.Domain.Models;
using WebAPI.Infra.Repositories.CompanyRepositoryName;
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
            var employeesDTO = new List<ReadEmployeeDTO>();
            foreach (var item in employees)
            {
                employeesDTO.Add(_mapper.Map<ReadEmployeeDTO>(item));
            }
            return Ok(employeesDTO);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployeeById([FromRoute] int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            return Ok(_mapper.Map<ReadEmployeeDTO>(employee));
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


        [HttpPut]
        [Route("update/{id}")]
        public IActionResult UpdateEmployee([FromRoute] int id, [FromBody] UpdateEmployeeDTO employeeDTO)
        {
            var isSucced = _employeeRepository.UpdateEmployee(id, employeeDTO);
            if (isSucced) return Ok();
            return NotFound("Employee not found.");
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id) 
        {
            var isSucced = _employeeRepository.DeleteEmployee(id);
            if (isSucced) return Ok();
            return NotFound("Employee not found.");
        }
    } 
}
