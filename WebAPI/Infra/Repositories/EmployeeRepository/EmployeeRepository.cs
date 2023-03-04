using WebAPI.Domain.DTOs;
using WebAPI.Domain.Models;

namespace WebAPI.Infra.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ApplicationDbContext _dbcontext;
        public EmployeeRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool Add(Employee employee)
        {
            _dbcontext.Add(employee);
            int changes = _dbcontext.SaveChanges();
            if (changes > 0) return true;
            return false;
        }

        public Employee GetEmployee(int id)
        {
            var employee = _dbcontext.Employees.Find(id);
            if (employee == null)
            {
                throw new Exception("User not found.");
            }
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _dbcontext.Employees.ToList();
        }

        public bool DeleteEmployee(int id)
        {
            var employee = GetEmployee(id);
            if (employee != null) _dbcontext.Remove(employee);
            int changes = _dbcontext.SaveChanges();
            if (changes > 0) return true;
            return false;
        }

        public bool UpdateEmployee(int id, Employee model)
        {
            var employee = GetEmployee(id);
            if (employee != null)
            {
                employee.Age = model.Age;
                employee.Name = model.Name;
                employee.Photo = model.Photo;
                employee.CurrentCompany = model.CurrentCompany;
            }
            int changes = _dbcontext.SaveChanges();
            if (changes > 0) return true;
            return false;
        }
    }
}
