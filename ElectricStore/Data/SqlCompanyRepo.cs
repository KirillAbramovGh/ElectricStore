using System.Collections.Generic;
using System.Linq;
using ElectricStore.Models;

namespace ElectricStore.Data
{
    public class SqlCompanyRepo : ICompanyRepo
    {
        private ElectricStoreContext _context;
        
        public SqlCompanyRepo(ElectricStoreContext context)
        {
            _context = context;
        }
        
        public List<Company> GetAllCompanies()
        {
            return _context.Companies.ToList();
        }

        public Company GetCompanyById(int companyId)
        {
            return _context.Companies.FirstOrDefault(c=>c.Id==companyId);
        }

        public void CreateCompany(Company company)
        {
            _context.Companies.Add(company);
        }

        public void UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
        }

        public void DeleteCompany(int companyId)
        {
            Company company = new Company() { Id = companyId };
            _context.Companies.Attach(company);
            _context.Companies.Remove(company);
        }
        
        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}