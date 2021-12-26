using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApplication.Controller
{
    public class EmployeeController
    {
        private EmployeeService _employeeService { get; }

        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }
        public void Create()
        {
            Helper.WriteToConsole(ConsoleColor.Green, "Please add the ID of the company of the employee:");
            EnterAgainId: string id = Console.ReadLine();
            int companyId;
            bool isTrueId = int.TryParse(id, out companyId);

            if (isTrueId)
            {
                Helper.WriteToConsole(ConsoleColor.Green, "Please add the name of the employee:");
                EnterAgainName: string employeeName = Console.ReadLine();
                if (!string.IsNullOrEmpty(employeeName))
                {
                    Helper.WriteToConsole(ConsoleColor.Green, "Please add the surname of the employee:");
                    EnterAgainSurname: string employeeSurname = Console.ReadLine();

                    if (!string.IsNullOrEmpty(employeeSurname))
                    {
                        Helper.WriteToConsole(ConsoleColor.Green, "Please add the age of the employee:");
                        EnterAgainAge: string employeeAge = Console.ReadLine();
                        int Age;
                        bool isTrueCount = int.TryParse(employeeAge, out Age);

                        if (isTrueCount)
                        {
                            Employee employee = new Employee
                            {
                                Name = employeeName,
                                Surname = employeeSurname,
                                Age = Age
                            };
                            Employee employee0 = _employeeService.Create(employee, companyId);

                            if (employee0 != null)
                            {
                                Helper.WriteToConsole(ConsoleColor.Blue, $"The company name (the company ID)  :  {employee0.company.Name} ({employee0.company.Id})");
                                Helper.WriteToConsole(ConsoleColor.Blue, $"The ID of the employee             :  {employee0.Id}");
                                Helper.WriteToConsole(ConsoleColor.Blue, $"The employee name                  :  {employee0.Name}");
                                Helper.WriteToConsole(ConsoleColor.Blue, $"The employee address               :  {employee0.Age}");
                            }
                            else
                            {
                                Helper.WriteToConsole(ConsoleColor.Red, "The company could not be found.");
                                goto EnterAgainId;
                            }
                        }
                        else
                        {
                            Helper.WriteToConsole(ConsoleColor.Red, "The age of the employee should only be consisted of number, please add again:");
                            goto EnterAgainAge;
                        }
                    }
                    else
                    {
                        Helper.WriteToConsole(ConsoleColor.Red, "The surname of the employee is required, please add again:");
                        goto EnterAgainSurname;
                    }
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "The name of the employee is required, please add again:");
                    goto EnterAgainName;
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "The Id of the company should only be consisted of number, please add again:");
                goto EnterAgainId;
            }


            


            
        }

            
        public void Update()
        {

        }
        public void GetByID()
        {

        }
        public void Delete()
        {

        }
        public void GetByAge()
        {

        }
        public void GetAllByCompanyId()
        {

        }
    }
}
