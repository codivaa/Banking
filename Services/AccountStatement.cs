using System;
using ConsoleBankingSystem.Properties;
using ConsoleBankingSystem.Services.TransactionHistory;

namespace ConsoleBankingSystem.Services.AccountStatement
{
    public class AccountStatementService
    {
        private readonly TransactionHistoryService transactionHistoryService = new TransactionHistoryService();

        public void ViewStatement(Account account)
        {
            Console.Clear();
            Console.WriteLine("=== ACCOUNT STATEMENT ===\n");

            if (account == null)
            {
                Console.WriteLine("❌ No account found.");
                Console.ReadKey();
                return;
            }

            var transactions = transactionHistoryService.GetTransactionHistory(account);

            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions yet.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Account Type: {account.AccountType}");
            Console.WriteLine($"Balance: ₦{account.Balance:N2}\n");

            Console.WriteLine("Date\t\t\tType\t\t Amount \t\t Balance After");
            Console.WriteLine("---------------------------------------------------------------------");

            foreach (var t in transactions)
            {
               Console.WriteLine($"{t.Date:G}\t{t.Type}\t\t₦{t.Amount:N2}\t\t₦{t.BalanceAfter:N2}");
            }

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }
    }
}
