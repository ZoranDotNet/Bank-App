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
    }
}
