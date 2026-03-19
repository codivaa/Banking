using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankingSystem.Properties
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public Customer Customer { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}

