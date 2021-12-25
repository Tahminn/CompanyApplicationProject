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
                Helper.WriteToConsole(ConsoleColor.Blue, $"The registration for the company named '{company.Name}' " +
                                                      $"has been created (The company address: {company.Address})." +
                                                         $"The registration ID of the new company is '{company.Id}'.");
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Wrong choice");
                goto EnterAgain;
            }
        }
        public void Update()
        {

        }
        public void Delete()
        {

        }
        public void GetById()
        {
            Helper.WriteToConsole(ConsoleColor.Green, "Please write down the ID of the company you want:");
            string companyId = Console.ReadLine();
            EnterIdAgain: int id;

            bool isIdTrue = int.TryParse(companyId, out id);

            if (isIdTrue)
            {
                var company1 = _companyService.GetById(id);

                if (company1 == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "The ID you entered does not match " +
                          "with any registration code in the system, please write an existing ID:");
                    return;
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Green, $"The registration ID  :  {company1.Id} ");
                    Helper.WriteToConsole(ConsoleColor.Green, $"The company name     :  {company1.Name} ");
                    Helper.WriteToConsole(ConsoleColor.Green, $"The company address  :  {company1.Address} ");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Since the registration Id was specified " +
                                                          "by numbers, Please enter only numbers:");
                return;
            }
        }
        public void GetAllByName()
        {

        }
        public void GetAll()
        {

        }
    }
}
