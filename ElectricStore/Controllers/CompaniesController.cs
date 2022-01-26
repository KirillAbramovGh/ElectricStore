using System.Collections.Generic;
using ElectricStore.Data;
using ElectricStore.Dtos;
using ElectricStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElectricStore.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepo _repo;
        // private readonly IMapper _mapper;

        public CompaniesController(ICompanyRepo repo)
        {
            _repo = repo;
            //_mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Company>> GetAllCompanies()
        {
            return Ok(_repo.GetAllCompanies());
        }

        [HttpGet("{id}")]
        public ActionResult<Company> GetCompanyById(int id)
        {
            var company = _repo.GetCompanyById(id);
            if (company != null)
            {
                return Ok(company);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Company> CreateCompany(Company company)
        {
            _repo.CreateCompany(company);
            _repo.SaveChanges();
            return Ok(company);
        }
        
        [HttpPut]
        public ActionResult UpdateCompany(int id, Company company)
        {
            var art = _repo.GetCompanyById(id);
            if (art == null || company.Id != id)
            {
                return NotFound();
            }
            _repo.UpdateCompany(company);
            _repo.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCompany(int id)
        {
            _repo.DeleteCompany(id);
            _repo.SaveChanges();
            return NoContent();
        }
    }
}