using System;
using System.Collections.Generic;
using ConsoleBankingSystem.Properties;

namespace ConsoleBankingSystem.Services.TransactionHistory
{
    public class TransactionHistoryService
    {
        // Adds a transaction record to a given account
        public void AddTransaction(Account account, string type, decimal amount, string description)
        {
            var transaction = new Transaction
            {
                Date = DateTime.Now,
                Type = type,
                Amount = amount,
                BalanceAfter = account.Balance,
                Description = description
            };

            account.Transactions.Add(transaction);
        }

        // Returns a read-only copy of transaction history
        public List<Transaction> GetTransactionHistory(Account account)
        {
            return new List<Transaction>(account.Transactions);
        }
    }
}
