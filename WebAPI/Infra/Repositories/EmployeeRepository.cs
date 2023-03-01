using WebAPI.Domain.DTOs;
using WebAPI.Domain.Models;

namespace WebAPI.Infra.Repository
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

        public EmployeeDTO GetEmployee(int id)
        {
            var employee = _dbcontext.Employees.Find(id);
            if (employee == null)
            {
                throw new Exception();
            }
            return new EmployeeDTO(){
                NameEmployee= employee.Name,
                Id = employee.Id
            };
        }

        public List<EmployeeDTO> GetEmployees()
        {
            return _dbcontext.Employees.Select(e =>
                new EmployeeDTO()
                {
                    NameEmployee = e.Name,
                    Id = e.Id
                }
            ).ToList();
        }
    }
}
