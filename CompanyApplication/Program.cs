using CompanyApplication.Controller;
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
            CompanyController companyController = new CompanyController();
            EmployeeController employeeController = new EmployeeController();

            Helper.WriteToConsole(ConsoleColor.Green, "Please select any option from down below:");

            while (true)
            {
                GetOptions();

                EnterOptionAgain: string selectOption = Console.ReadLine();
                int option;
                bool isTrueOption = int.TryParse(selectOption, out option);

                if (isTrueOption)
                {
                    switch (option)
                    {
                        case (int)OptionEnums.Options.CreateCompany: companyController.Create();                         
                            break;

                        case (int)OptionEnums.Options.UpdateCompany: companyController.Update();
                            break;

                        case (int)OptionEnums.Options.DeleteCompany: companyController.Delete();
                            break;

                        case (int)OptionEnums.Options.GetCompanyByID: companyController.GetById();                                                       
                            break;

                        case (int)OptionEnums.Options.GetAllCompanyByName: companyController.GetAllByName();   
                            break;

                        case (int)OptionEnums.Options.GetAllCompany: companyController.GetAll();   
                            break;

                        case (int)OptionEnums.Options.CreateEmployee: employeeController.Create();   
                            break;

                        case (int)OptionEnums.Options.UpdateEmployee: employeeController.Update();   
                            break;

                        case (int)OptionEnums.Options.GetEmployeeByID: employeeController.GetByID();   
                            break;

                        case (int)OptionEnums.Options.DeleteEmployee: employeeController.Delete();   
                            break;

                        case (int)OptionEnums.Options.GetEmployeeByAge: employeeController.GetByAge();   
                            break;

                        case (int)OptionEnums.Options.GetAllEmployeeByCompanyId: employeeController.GetAllByCompanyId();   
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

        private static void GetOptions()
        {
            Helper.WriteToConsole(ConsoleColor.Yellow, "1 - Create Company;   4 - Get Company by ID;         7 - Create Employee;      10 - Delete Employee;");
            Helper.WriteToConsole(ConsoleColor.Yellow, "2 - Update Company;   5 - Get all Company by name;   8 - Update Employee;      11 - Get Employee by age;");
            Helper.WriteToConsole(ConsoleColor.Yellow, "3 - Delete Company;   6 - Get all Company;           9 - Get Employee by ID;   12 - Get all Employee by Company ID;");
        }
    }
}
