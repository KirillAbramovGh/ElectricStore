using System.Collections.Generic;
using ElectricStore.Models;

namespace ElectricStore.Data
{
    public interface ICompanyRepo
    {
        public List<Company> GetAllCompanies();

        public Company GetCompanyById(int companyId);

        public void CreateCompany(Company company);

        public void UpdateCompany(Company company);

        public void DeleteCompany(int companyId);
        
        bool SaveChanges();
    }
}