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
        public IActionResult Add(EmployeeViewModel employeeViewModel)
        {
            var employee = new Employee(employeeViewModel.Name, employeeViewModel.Age, null);
            _repository.Add(employee);
            return Ok(employee);
        }
        [HttpGet]
        [Route("get")]
        public IActionResult GetEmployees()
        {
            _logger.Log(LogLevel.Error, "Teve um erro");

            var employees = _repository.GetEmployees();

            _logger.LogInformation("Teste");
            return Ok(employees);
        }


        [HttpGet]
        [Route("getById/{id}")]
        public IActionResult GetEmployeeById([FromRoute] int id)
        {
            var employee = _repository.GetEmployee(id);
            return Ok(employee);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Search([FromRoute] int id)
        {
            var employee = _repository.GetEmployee(id);
            return Ok(_mapper.Map<EmployeeDTO>(employee));
        }
    }
}
