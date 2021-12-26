using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface IEmployeeService
    {
        Employee Create(Employee model, int companyId);
        void Delete(Employee employee);
        Employee GetById(int id);
        List<Employee> GetByAge(int Age);
        List<Employee> GetAllByCompanyId(int companyId);
        Employee Update(int id, Employee model, Company company);        
    }
}
