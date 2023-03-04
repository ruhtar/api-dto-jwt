using WebAPI.Domain.Models;

namespace WebAPI.Infra.Repositories.CompanyRepository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public CompanyRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Add(Company company)
        {
            _dbcontext.Add(company);
            _dbcontext.SaveChanges();
        }

        public void DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetCompaneis()
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(int id)
        {
            var company = _dbcontext.Companies.Find(id);
            return company;
        }

        public void UpdateCompany(int id, Company companyModel)
        {
            throw new NotImplementedException();
        }
    }
}
