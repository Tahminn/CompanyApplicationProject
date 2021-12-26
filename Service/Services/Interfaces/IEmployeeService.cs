using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface IEmployeeService
    {
        Employee Create(Employee model);
        Employee Update(int id, Employee model);
        void Delete(Employee model, int id);
        Employee GetById(int id);
        //Employee GetByAge(int age);
        //List<Employee> GetAllByCompanyID(Predicate<Employee> filter);
    }
}
