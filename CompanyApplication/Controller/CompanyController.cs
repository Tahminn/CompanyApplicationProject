using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApplication.Controller
{
    public class CompanyController
    {
        private CompanyService _companyService { get; }

        public CompanyController()
        {
            _companyService = new CompanyService();
        }
        
        public void Create()
        {
            Helper.WriteToConsole(ConsoleColor.Green, "Please name the company:");
            EnterAgain: string companyName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Green, "Please write the address of the company:");
            string companyAddress = Console.ReadLine();
            Company company = new Company
            {
                Name = companyName,
                Address = companyAddress
            };
            var company0 = _companyService.Create(company);

            if (company0 != null)
            {
                Helper.WriteToConsole(ConsoleColor.Blue, $"The registration ID  :  {company0.Id}");
                Helper.WriteToConsole(ConsoleColor.Blue, $"The company name     :  {company0.Name}");
                Helper.WriteToConsole(ConsoleColor.Blue, $"The company address  :  {company0.Address}");
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Wrong choice");
                goto EnterAgain;
            }
        }
        public void Update()
        {
            Helper.WriteToConsole(ConsoleColor.Green, "Please write down the ID of the company you want to update:");
            EnterIdAgain: string companyId = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(companyId, out id);

            Helper.WriteToConsole(ConsoleColor.Green, "Please write down the new name for the company");
            string newName = Console.ReadLine();

            Helper.WriteToConsole(ConsoleColor.Green, "Please write down the new address for the company");
            string newAddress = Console.ReadLine();
            
            if (isIdTrue)
            {
                Company company = new Company
                {
                    Name = newName,
                    Address = newAddress
                };

                Company newCompany = _companyService.Update(id, company);

                Helper.WriteToConsole(ConsoleColor.Blue, $"The registration ID  :  {newCompany.Id}");
                Helper.WriteToConsole(ConsoleColor.Blue, $"The updated name     :  {newCompany.Name}");
                Helper.WriteToConsole(ConsoleColor.Blue, $"The updated address  :  {newCompany.Address}");

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
            EnterIdAgain: string companyId = Console.ReadLine();
            int id;

            bool isIdTrue = int.TryParse(companyId, out id);

            if (isIdTrue)
            {
                var company = _companyService.GetById(id);
                  
                if (company == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "The ID you entered does not match " +
                          "with any registration code in the system, please write an existing ID:");
                    goto EnterIdAgain;
                }
                else
                {
                    _companyService.Delete(company);
                    Helper.WriteToConsole(ConsoleColor.Green, $"The company named '{company.Name}' with the registration ID of '{company.Id}' has been removed from the system.");                    
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Since the registration Id was specified " +
                                                          "by numbers, Please enter only numbers:");
                goto EnterIdAgain;
            }

        }
        public void GetById()
        {
            Helper.WriteToConsole(ConsoleColor.Green, "Please write down the ID of the company you want:");
            EnterIdAgain: string companyId = Console.ReadLine();
            int id;

            bool isIdTrue = int.TryParse(companyId, out id);

            if (isIdTrue)
            {
                var company = _companyService.GetById(id);

                if (company == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "The ID you entered does not match " +
                          "with any registration code in the system, please write an existing ID:");
                    goto EnterIdAgain;
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The registration ID  :  {company.Id} ");
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The company name     :  {company.Name} ");
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The company address  :  {company.Address} ");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Since the registration Id was specified " +
                                                          "by numbers, Please enter only numbers:");
                goto EnterIdAgain;
            }
        }
        public void GetAllByName()
        {

            Helper.WriteToConsole(ConsoleColor.Green, "Please write down the name of the company you want:");
            EnterIdAgain: string companyName = Console.ReadLine();
            int id;

            bool isIdTrue = int.TryParse(companyName, out id);

            if (isIdTrue)
            {
                var company = _companyService.GetById(id);

                if (company == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "The ID you entered does not match " +
                          "with any registration code in the system, please write an existing ID:");
                    goto EnterIdAgain;
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The registration ID  :  {company.Id} ");
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The company name     :  {company.Name} ");
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The company address  :  {company.Address} ");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Since the registration Id was specified " +
                                                          "by numbers, Please enter only numbers:");
                goto EnterIdAgain;
            }
        }
        public void GetAll()
        {
            var companies = _companyService.GetAll();
            foreach (var item in companies)
            {
                if (item.Id == 0 || item.Id % 2 == 0)
                {
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The registration ID  :  {item.Id} ");
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The company name     :  {item.Name} ");
                    Helper.WriteToConsole(ConsoleColor.Blue, $"The company address  :  {item.Address} ");
                    Console.WriteLine();

                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.DarkRed, $"The registration ID  :  {item.Id} ");
                    Helper.WriteToConsole(ConsoleColor.DarkRed, $"The company name     :  {item.Name} ");
                    Helper.WriteToConsole(ConsoleColor.DarkRed, $"The company address  :  {item.Address} ");
                    Console.WriteLine();
                }
                
            }
        }
    }
}
