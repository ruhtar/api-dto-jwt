using WebAPI.Domain.DTOs;
using WebAPI.Domain.Models;

namespace WebAPI.Infra.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
        void DeleteEmployee(int id);
        void UpdateEmployee(int id, Employee model);
    }
}
