using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleBankingSystem.Properties;
using ConsoleBankingSystem.Services.TransactionHistory;
using ConsoleBankingSystem.Services.AccountStatement;

namespace ConsoleBankingSystem.Services
{
    public class AccountServices
    {
        private static List<Account> accounts = new List<Account>();
        private static int nextAccountId = 1;
        private static readonly Random rand = new Random();

        private readonly TransactionHistoryService transactionHistoryService = new TransactionHistoryService();
        private readonly AccountStatementService accountStatementService = new AccountStatementService();

        public void CreateAccount(Customer customer)
        {
            Console.Clear();
            Console.WriteLine("=== CREATE ACCOUNT ===\n");

            Console.WriteLine("Select Account Type:");
            Console.WriteLine("1. Savings");
            Console.WriteLine("2. Current");
            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out int typeChoice) || (typeChoice < 1 || typeChoice > 2))
            {
                Console.WriteLine("❌ Invalid choice.");
                Console.ReadKey();
                Dashboard.getMenu(customer);
                return;
            }

            AccountType type = typeChoice == 1 ? AccountType.savings : AccountType.Current;
            string accNumber = $"ANG{rand.Next(100000, 999999)}";

            var account = new Account
            {
                Id = nextAccountId++,
                AccountNumber = accNumber,
                Customer = customer,
                AccountType = type,
                Balance = 0m
            };

            accounts.Add(account);

            Console.WriteLine($"\n✅ Account created successfully!");
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Type: {account.AccountType}");
            Console.WriteLine($"Balance: ₦{account.Balance:N2}");
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
            Dashboard.getMenu(customer);
        }

        public void Deposit(Customer customer)
        {
            Console.Clear();
            Console.WriteLine("=== DEPOSIT ===\n");

            var account = FindCustomerAccount(customer);
            if (account == null)
            {
                Console.WriteLine("❌ No account found. Please create one first.");
                Console.ReadKey();
                Dashboard.getMenu(customer);
                return;
            }

            Console.Write("Enter amount to deposit: ₦");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("❌ Invalid amount.");
                Console.ReadKey();
                Dashboard.getMenu(customer);
                return;
            }

            account.Balance += amount;

            // ✅ Log Transaction
            transactionHistoryService.AddTransaction(account, "Deposit", amount, "Deposit made successfully");

            Console.WriteLine($"\n✅ Deposit successful! New balance: ₦{account.Balance:N2}");
            Console.ReadKey();
            Dashboard.getMenu(customer);
        }

        public void Withdraw(Customer customer)
        {
            Console.Clear();
            Console.WriteLine("=== WITHDRAW ===\n");

            var account = FindCustomerAccount(customer);
            if (account == null)
            {
                Console.WriteLine("❌ No account found. Please create one first.");
                Console.ReadKey();
                Dashboard.getMenu(customer);
                return;
            }

            Console.Write("Enter amount to withdraw: ₦");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("❌ Invalid amount.");
                Console.ReadKey();
                Dashboard.getMenu(customer);
                return;
            }

            if (amount > account.Balance)
            {
                Console.WriteLine("❌ Insufficient funds!");
            }
            else
            {
                account.Balance -= amount;
                transactionHistoryService.AddTransaction(account, "Withdrawal", amount, "Withdrawal processed");
                Console.WriteLine($"\n✅ Withdrawal successful! New balance: ₦{account.Balance:N2}");
            }

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
            Dashboard.getMenu(customer);
        }

        // ✅ NEW: View Account Statement using dedicated service
        public void ViewStatement(Customer customer)
        {
            var account = FindCustomerAccount(customer);
            accountStatementService.ViewStatement(account);
            Dashboard.getMenu(customer);
        }

        private Account FindCustomerAccount(Customer customer)
        {
            return accounts.FirstOrDefault(a => a.Customer.Email == customer.Email);
        }
    }
}

