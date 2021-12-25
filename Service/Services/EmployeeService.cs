using Domain.Models;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        public Employee Create(Employee model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee model)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllByCompanyID(Predicate<Employee> filter)
        {
            throw new NotImplementedException();
        }

        public Employee GetByAge(int age)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(int id, Employee model)
        {
            throw new NotImplementedException();
        }
    }
}
