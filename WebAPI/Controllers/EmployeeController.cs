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
        public EmployeeController(IEmployeeRepository repository) {
            _repository = repository;
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
        [Authorize]
        [HttpGet]
        [Route("get")]
        public IActionResult GetGetEmployeesEmployee()
        {
            var employees = _repository.GetEmployees();
            return Ok(employees);
        }
    }
}
