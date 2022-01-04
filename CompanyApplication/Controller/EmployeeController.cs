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
                                Helper.WriteToConsole(ConsoleColor.Blue, $"The employee surname               :  {employee0.Surname}");
                                Helper.WriteToConsole(ConsoleColor.Blue, $"The employee Age                   :  {employee0.Age}");
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
            Helper.WriteToConsole(ConsoleColor.Green, "Please add the ID of the employee: ");
            EnterCoIdAgain: string CompanyId = Console.ReadLine();
            int companyId;
            bool isTrueId = int.TryParse(CompanyId, out companyId);

            if (isTrueId)
            {
                Helper.WriteToConsole(ConsoleColor.Green, "Please add the new name of the emloyee:");
                EnterAgainName: string newName = Console.ReadLine();

                if (!string.IsNullOrEmpty(newName))
                {
                    Helper.WriteToConsole(ConsoleColor.Green, "Please add the new surname of the emloyee:");
                    EnterAgainSurname: string newSurname = Console.ReadLine();

                    if (!string.IsNullOrEmpty(newSurname))
                    {
                        Helper.WriteToConsole(ConsoleColor.Green, "Please add the new age of the emloyee:");
                        EnterAgainAge: string newAge = Console.ReadLine();

                        int employeAge;
                        bool isTrueAge = int.TryParse(newAge, out employeAge);

                        if (isTrueAge)
                        {
                            var newCompany = _employeeService.GetById(companyId);

                            Employee employee = new Employee
                            {
                                Name = newName,
                                Surname = newSurname,
                            };
                            var company = new Company();

                            var newEmployee = _employeeService.Update(employee.Id, employee);

                            Helper.WriteToConsole(ConsoleColor.Blue, $"The company name (the company ID)  :  {newEmployee.company.Name} ({newEmployee.company.Id})");
                            Helper.WriteToConsole(ConsoleColor.Blue, $"The ID of the employee             :  {newEmployee.Id}");
                            Helper.WriteToConsole(ConsoleColor.Blue, $"The employee name                  :  {newEmployee.Name}");
                            Helper.WriteToConsole(ConsoleColor.Blue, $"The employee surname               :  {newEmployee.Surname}");
                            Helper.WriteToConsole(ConsoleColor.Blue, $"The employee Age                   :  {newEmployee.Age}");
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
                Helper.WriteToConsole(ConsoleColor.Red, "The Id of the employee should only be consisted of number, please add again:");
                goto EnterCoIdAgain;
            }

            
        }            
        public void GetByID()
        {
            Helper.WriteToConsole(ConsoleColor.Green, "Please write down the ID of the employee you want:");
            EnterIdAgain: string employeeId = Console.ReadLine();
            int id;

            bool isIdTrue = int.TryParse(employeeId, out id);

            if (isIdTrue)
            {
                var employee = _employeeService.GetById(id);

                if (employee == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "The ID you entered does not match " +
                          "with any registration code in the system, please write an existing ID:");
                    goto EnterIdAgain;
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The company name and ID  :  {employee.company.Name} ({employee.company.Id})");
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The registration ID      :  {employee.Id} ");
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The company name         :  {employee.Name} ");
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The employee surname     :  {employee.Surname}");
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The employee Age         :  {employee.Age}");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Since the registration Id was specified " +
                                                          "by numbers, Please enter only numbers:");
                goto EnterIdAgain;
            }
        }
        public void Delete()
        {
            Helper.WriteToConsole(ConsoleColor.Green, "Please write down the ID of the company you want to remove from the system:");
        EnterIdAgain: string employeeId = Console.ReadLine();
            int id;

            bool isIdTrue = int.TryParse(employeeId, out id);

            if (isIdTrue)
            {
                var employee = _employeeService.GetById(id);

                if (employee == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "The ID you entered does not match " +
                          "with any registration code in the system, please write an existing ID:");
                    goto EnterIdAgain;
                }
                else
                {
                    _employeeService.Delete(employee);
                    Helper.WriteToConsole(ConsoleColor.Green, $"The employee named '{employee.Name}' with the registration ID of '{employee.Id}' has been removed from the system.");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Since the registration Id was specified " +
                                                          "by numbers, Please enter only numbers:");
                goto EnterIdAgain;
            }

        }
        public void GetByAge()
        {
            Helper.WriteToConsole(ConsoleColor.Green, "Please write down the age of the employee you want:");
            EnterAgeAgain: string employeeAge = Console.ReadLine();
            int age;

            bool isAgeTrue = int.TryParse(employeeAge, out age);

            if (isAgeTrue)
            {
                var employee = _employeeService.GetByAge(age);

                if (employee == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "The ID you entered does not match " +
                           "with any registration code in the system, please write an existing ID:");
                    goto EnterAgeAgain;
                }
                else
                {
                    foreach (var item in employee)
                    {
                        Helper.WriteToConsole(ConsoleColor.Blue, $"The company name and ID  :  {item.Name} ({item.company.Id})");
                        Helper.WriteToConsole(ConsoleColor.Blue, $"The registration ID      :  {item.Id} ");
                        Helper.WriteToConsole(ConsoleColor.Blue, $"The company name         :  {item.Name} ");
                        Helper.WriteToConsole(ConsoleColor.Blue, $"The employee surname     :  {item.Surname}");
                        Helper.WriteToConsole(ConsoleColor.Blue, $"The employee Age         :  {item.Age}");
                        Console.WriteLine();
                    }                    
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Since the registration Id was specified " +
                                                          "by numbers, Please enter only numbers:");
                goto EnterAgeAgain;
            }
        }
        public void GetAllByCompanyId()
        {
            Helper.WriteToConsole(ConsoleColor.Green, "Please write down the ID of the company you want:");
            EnterIdAgain: string companyId = Console.ReadLine();
            int id;

            bool isIdTrue = int.TryParse(companyId, out id);

            if (isIdTrue)
            {
                var companies = _employeeService.GetAllByCompanyId(id);
                foreach (var item in companies)
                {
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The company name and ID  :  {item.company.Name} ({item.company.Id})");
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The registration ID      :  {item.Id} ");
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The company name         :  {item.Name} ");
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The employee surname     :  {item.Surname}");
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The employee Age         :  {item.Age}");
                }

            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Since the registration Id was specified " +
                                                          "by numbers, Please enter only numbers:");
                goto EnterIdAgain;
            }
        }
    }
}
        

