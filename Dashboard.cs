using System;
using ConsoleBankingSystem.Properties;
using ConsoleBankingSystem.Services;

namespace ConsoleBankingSystem
{
    public class Dashboard
    {
        public static void getMenu(Customer customer)
        {
            AccountServices accountServices = new AccountServices();

            Console.Clear();
            Console.WriteLine($"Welcome {customer.FirstName} {customer.LastName}!");
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("1. Open Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. View Account Statement");
            Console.WriteLine("5. Logout");
            Console.Write("Select option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    accountServices.CreateAccount(customer);
                    break;
                case "2":
                    accountServices.Deposit(customer);
                    break;
                case "3":
                    accountServices.Withdraw(customer);
                    break;
               
                case "4":
                    accountServices.ViewStatement(customer);
                    break;
                case "5":
                    Console.WriteLine("Logging out...");
                    Console.ReadKey();
                    Entry entry = new Entry();
                    entry.getStarted();
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    getMenu(customer);
                    break;
            }
        }
    }
}
