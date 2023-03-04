using WebAPI.Domain.Models;
using WebAPI.ViewModel;

namespace WebAPI.Infra.Repositories.CompanyRepositoryName
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public CompanyRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public bool Add(Company company)
        {
            _dbcontext.Add(company);
            int changes = _dbcontext.SaveChanges();
            if (changes > 0) return true;
            return false;
        }

        public bool DeleteCompany(int id)
        {
            var company = GetCompanyById(id);
            if (company == null)  return false; 
            _dbcontext.Companies.Remove(company);
            int changes = _dbcontext.SaveChanges();
            if (changes > 0) return true;
            return false;
        }

        public List<Company> GetCompanies()
        {
            return _dbcontext.Companies.ToList();
        }

        public Company GetCompanyById(int id)
        {
            var company = _dbcontext.Companies.Find(id);
            return company;
        }

        public bool UpdateCompany(int id, CompanyViewModel companyModel)
        {
            var company = GetCompanyById(id);
            if (company == null)  return false; 
            company.Address = companyModel.Address;
            company.Name = companyModel.Name;
            int changes = _dbcontext.SaveChanges();
            if (changes > 0) return true;
            return false;

        }
    }
}
