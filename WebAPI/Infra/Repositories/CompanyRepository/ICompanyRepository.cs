using WebAPI.Domain.Models;

namespace WebAPI.Infra.Repositories.CompanyRepository
{
    public interface ICompanyRepository
    {
        void Add(Company company);
        List<Company> GetCompaneis();
        Company GetCompany(int id);
        void DeleteCompany(int id);
        void UpdateCompany(int id, Company companyModel);
    }
}
