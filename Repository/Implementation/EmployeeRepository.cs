using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public bool Create(Employee entity)
        {
            try
            {
                if (entity == null) throw new CustomException("Entity is null");
                AppDbContext<Employee>.datas.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(Employee entity)
        {
            try
            {
                AppDbContext<Employee>.datas.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Employee Get(Predicate<Employee> filter = null)
        {
            return filter == null ? AppDbContext<Employee>.datas[0] : AppDbContext<Employee>.datas.Find(filter);
        }

        public List<Employee> GetAll(Predicate<Employee> filter)
        {
            return filter == null ? AppDbContext<Employee>.datas : AppDbContext<Employee>.datas.FindAll(filter);
        }

        public bool Update(Employee entity)
        {
            try
            {
                var company = Get(m => m.Id == entity.Id);
                if (company != null)
                {
                    if (!string.IsNullOrEmpty(entity.Name)) company.Name = entity.Name;
                    //if (!string.IsNullOrEmpty(entity.Age).ToString) company.Age = entity.Age;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


        }
    }
}
