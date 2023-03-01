using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Infra.Repository;
using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        private readonly ILogger<EmployeeController> _logger; 
        public EmployeeController(IEmployeeRepository repository, ILogger<EmployeeController> logger)
        {
            _repository = repository;
            _logger = logger;
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
        public IActionResult GetEmployeesEmployee()
        {
            _logger.Log(LogLevel.Error, "Teve um erro");

            var employees = _repository.GetEmployees();

            _logger.LogInformation("Teste");
            return Ok(employees);
        }
    }
}
