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

        public List<Employee> GetEmployees()
        {
            return _dbcontext.Employees.ToList();
        }
    }
}
