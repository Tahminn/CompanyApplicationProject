using Domain.Models;
using Repository.Implementation;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class CompanyService : ICompanyService
    {
        private CompanyRepository companyRepository;
        private int count { get; set; }
        public CompanyService()
        {
            companyRepository = new CompanyRepository();
        }

        public Company Create(Company model)
        {
            model.Id = count;
            companyRepository.Create(model);
            count++;
            return model;
        }

        public void Delete(Company company)
        {            
            companyRepository.Delete(company);
        }

        public Company GetById(int id)
        {
            return companyRepository.Get(m => m.Id == id);           
        }

        public List<Company> GetAllByName(string name)
        {
            return companyRepository.GetAll(m=>m.Name == name);
        }

        public Company Update(int id, Company model)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetAll()
        {
            return companyRepository.GetAll(null);
        }
    }
}
