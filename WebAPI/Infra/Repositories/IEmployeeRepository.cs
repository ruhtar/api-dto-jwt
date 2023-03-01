using WebAPI.Domain.DTOs;
using WebAPI.Domain.Models;

namespace WebAPI.Infra.Repository
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        List<EmployeeDTO> GetEmployees();
        EmployeeDTO GetEmployee(int id);
    }
}
