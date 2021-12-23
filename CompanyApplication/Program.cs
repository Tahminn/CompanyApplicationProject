using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;

namespace CompanyApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            CompanyService companyService = new CompanyService();
            Helper.WriteToConsole(ConsoleColor.Green, "Please select any option from down below:");
            while (true)
            {
                Helper.WriteToConsole(ConsoleColor.Yellow, "1 - Create Company;   4 - Get Company by ID;         7 - Create Employee;      10 - Delete Employee;  ");
                Helper.WriteToConsole(ConsoleColor.Yellow, "2 - Update Company;   5 - Get all Company by name;   8 - Update Employee;      11 - Get Employee by age;");
                Helper.WriteToConsole(ConsoleColor.Yellow, "3 - Delete Company;   6 - Get all Company;           9 - Get Employee by ID;   12 - Get all Employee by Company ID;");

                EnterOptionAgain: string selectOption = Console.ReadLine();
                int option;

                bool isTrueOption = int.TryParse(selectOption, out option);

                if (isTrueOption)
                {
                    switch (option)
                    {
                        case 1:
                            Helper.WriteToConsole(ConsoleColor.Green, "Please name the company:");
                            string companyName = Console.ReadLine();
                            Helper.WriteToConsole(ConsoleColor.Green, "Please write the address of the company:");
                            string companyAddress = Console.ReadLine();
                            Company company = new Company
                            {
                                Name = companyName,
                                Address = companyAddress
                            };
                            var result = companyService.Create(company);

                            if(result != null)
                            {
                                Helper.WriteToConsole(ConsoleColor.Blue, $"The registration for the company called {company.Name} has been created. "+
                                                                         $"(Company address: {company.Address}" +
                                                                         $" The registration ID of the new company is {company.Id}"); ;
                            }
                            else
                            {
                                Helper.WriteToConsole(ConsoleColor.Red, "Wrong choice");
                                return;
                            }

                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Please enter a valid option between 1-12");
                    goto EnterOptionAgain;
                }
            }

        }
    }
}
