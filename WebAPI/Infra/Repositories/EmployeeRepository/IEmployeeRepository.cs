using WebAPI.Domain.DTOs.EmployeeDTOs;
using WebAPI.Domain.Models;

namespace WebAPI.Infra.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        bool Add(Employee employee);
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
        bool DeleteEmployee(int id);
        bool UpdateEmployee(int id, UpdateEmployeeDTO model);
    }
}
