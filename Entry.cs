using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleBankingSystem;
using Console_bank.Services;

namespace ConsoleBankingSystem
{
    public class Entry
    {
        CustomerServices customerServices=new CustomerServices();
        public void getStarted()
        {
            var customer = new CustomerServices();

            Console.WriteLine("WELCOME TO BANK ANGIE");
            Console.WriteLine("HOW CAN WE HELP YOU TODAY");
            Console.WriteLine("FOLLOW ONE OF THE OPTIONS BELOW TO GET STARTED");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            string response = Console.ReadLine();
            if (response == "1")
            {
                customerServices.Register();
            }
        }
    }
}
