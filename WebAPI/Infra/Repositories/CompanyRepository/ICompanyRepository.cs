using WebAPI.Domain.Models;
using WebAPI.ViewModel;

namespace WebAPI.Infra.Repositories.CompanyRepositoryName
{
    public interface ICompanyRepository
    {
        bool Add(Company company);
        List<Company> GetCompanies();
        Company GetCompanyById(int id);
        bool DeleteCompany(int id);
        bool UpdateCompany(int id, CompanyViewModel companyModel);
    }
}
