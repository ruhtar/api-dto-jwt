using AutoMapper;
using WebAPI.Domain.DTOs.EmployeeDTOs;
using WebAPI.Domain.Models;
using WebAPI.Infra.Repositories.CompanyRepositoryName;

namespace WebAPI.Infra.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ApplicationDbContext _dbcontext;
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public EmployeeRepository(ApplicationDbContext dbcontext, IMapper mapper, ICompanyRepository companyRepository)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
            _companyRepository = companyRepository;
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

        public bool UpdateEmployee(int id, UpdateEmployeeDTO model)
        {
            var employee = GetEmployee(id);
            var company = _companyRepository.GetCompanyById(model.CurrentCompanyId);
            if (employee != null)
            {
                employee.Age = model.Age;
                employee.Name = model.Name;
                employee.CurrentCompany = company;
            }
            int changes = _dbcontext.SaveChanges();
            if (changes > 0) return true;
            return false;
        }
    }
}
