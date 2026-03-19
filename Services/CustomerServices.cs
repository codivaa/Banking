using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleBankingSystem;
using ConsoleBankingSystem.Properties;

namespace Console_bank.Services
{
    public class CustomerServices
    {
        private List<Customer> customers = new List<Customer>();//global scope
        private int nextId = 1;
        public void Register()
        {
            Console.Clear();
            Console.WriteLine("=== Customer Registration ===\n");

            Customer newCustomer = new Customer();
            newCustomer.Id = nextId++;

            Console.Write("Enter First Name: ");
            newCustomer.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            newCustomer.LastName = Console.ReadLine();

            Console.Write("Enter Email: ");
            newCustomer.Email = Console.ReadLine();

            Console.Write("Enter Password: ");
            newCustomer.Password = Console.ReadLine();

            // Optional: simple email validation
            if (string.IsNullOrWhiteSpace(newCustomer.Email) || !newCustomer.Email.Contains("@"))
            {
                Console.WriteLine("\nInvalid email address. Registration failed.\n");
                return;
            }

            customers.Add(newCustomer);

            Console.WriteLine($"\nCustomer registered successfully!");
            Console.WriteLine($"Customer ID: {newCustomer.Id}");
            Console.WriteLine($"Name: {newCustomer.FirstName} {newCustomer.LastName}");
            Console.WriteLine($"Email: {newCustomer.Email}\n");

            Console.WriteLine("Press 2 to Login");
            string response = Console.ReadLine();
            if (response == "2")
            {
                Login();
            }
        }

        public void Login()
        {
            Console.Clear();
            Console.WriteLine("=== Customer Login ===\n");

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Customer customer = customers.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (customer != null)
            {
                Dashboard.getMenu(customer);
            }
            else
            {
                Register();
            }
        }
    }
}

