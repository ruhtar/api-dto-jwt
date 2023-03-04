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
        public void Add(Employee employee)
        {
            _dbcontext.Add(employee);
            _dbcontext.SaveChanges();
        }

        public Employee GetEmployee(int id)
        {
            var employee = _dbcontext.Employees.Find(id);
            if (employee == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _dbcontext.Employees.ToList();
        }

        public void DeleteEmployee(int id)
        {
            var employee = GetEmployee(id);
            if (employee != null) _dbcontext.Remove(employee);
            _dbcontext.SaveChanges();
        }

        public void UpdateEmployee(int id, Employee model)
        {
            var employee = GetEmployee(id);
            if (employee != null)
            {
                employee.Age = model.Age;
                employee.Name = model.Name;
                employee.Photo = model.Photo;
                employee.CurrentCompany = model.CurrentCompany;
            }
            _dbcontext.SaveChanges();
        }
    }
}
