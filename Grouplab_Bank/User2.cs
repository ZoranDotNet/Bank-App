namespace Grouplab_Bank
{
    internal partial class User
    {
        public void GetTransactionHistory(User user)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            if (user.BankAccounts.Count == 0)
            {
                Console.WriteLine("You have no BankAccount!");
                Console.ReadKey();
                return;
            }
            foreach (BankAccount account in user.BankAccounts)
            {
                foreach (Transaction item in account.Transactions)
                {
                    Console.WriteLine($"{item.Date.ToShortDateString()} ***    {item.Amount.ToString("N2"),-13} *** {account.Currency,-8} *** {item.Type,-12} *** Account: {item.Account.AccountNumber}");
                    Console.WriteLine("*********************************************************************************");
                }
            }
            Console.ReadKey();
        }

        public void AddTransaction(BankAccount account, TransactionType type, decimal amount)
        {
            DateTime date = DateTime.Today;
            decimal transactionAmount = 0;

            //This makes it look like -1000 if it is withdraw or transfer from.
            if (type == TransactionType.Withdraw || type == TransactionType.Transfer_From)
            {
                transactionAmount = amount - 2 * amount;
            }
            else
            {
                transactionAmount = amount;
            }

            Transaction transaction = new Transaction(date, account, transactionAmount, type);
            if (account.Transactions == null)
            {
                account.Transactions = new List<Transaction>();
            }
            account.Transactions.Add(transaction);
        }
    }
}
