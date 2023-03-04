using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.DTOs;
using WebAPI.Domain.Models;
using WebAPI.Infra.Repository;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        private readonly ILogger<EmployeeController> _logger; 
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository repository, ILogger<EmployeeController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        [Authorize]
        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] EmployeeViewModel employeeViewModel)
        {
            //Funciona passa as infos dele e o id da empresa. 
            //Valida se a empresa existe, caso contrario, criá-la
            var employee = new Employee(employeeViewModel.Name, employeeViewModel.Age, null, null);
            _repository.Add(employee);
            return Ok(employee);
        }


        [HttpGet]
        [Route("")]
        public IActionResult GetEmployees()
        {
            var employees = _repository.GetEmployees();

            return Ok(employees);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployeeById([FromRoute] int id)
        {
            var employee = _repository.GetEmployee(id);
            return Ok(_mapper.Map<EmployeeDTO>(employee));
        }



    }
}
