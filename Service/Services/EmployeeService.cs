using Domain.Models;
using Repository.Exceptions;
using Repository.Implementation;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeRepository _employeeRepository;
        private CompanyRepository _companyRepository;
        private int count { get; set; }
        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
            _companyRepository = new CompanyRepository();
        }

        public Employee Create(Employee model, int companyId)
        {
            try
            {
                Company company = _companyRepository.Get(m => m.Id == companyId);
                if (company == null)
                {
                    return null;
                }
                else
                {
                    model.Id = count;
                    model.company = company;
                    _employeeRepository.Create(model);
                    count++;
                    return model;
                }                                                     
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void Delete(Employee employee)
        {
            _employeeRepository.Delete(employee);
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.Get(m => m.Id == id);
        }

        public List<Employee> GetAllByName(string name)
        {
            return _employeeRepository.GetAll(m => m.Name == name);
        }

        public Employee Update(int id, Employee model)
        {
            var employee = GetById(id);    
            model.Id = employee.Id;
            _employeeRepository.Update(model);
            return model;
        }

        public List<Employee> GetAll()
        {
            return _employeeRepository.GetAll(null);
        }

        public List<Employee> GetByAge(int age)
        {
            return _employeeRepository.GetAll(m => m.Age == age);
        }

        public List<Employee> GetAllByCompanyId(int companyId)
        {
            return _employeeRepository.GetAllByCompanyId(m => m.company.Id == companyId);
        }
    }
}
