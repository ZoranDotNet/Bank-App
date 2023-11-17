namespace Grouplab_Bank
{
    internal partial class BankAccount
    {
        public void GetBalance(User user)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (user.BankAccounts.Count == 0)
            {
                Console.WriteLine("You have no BankAccount");
                Console.ReadKey();
            }
            else
            {
                decimal total = 0;
                foreach (var item in user.BankAccounts)
                {
                    total += item.Balance;
                    Console.WriteLine($"*  {item.AccountNumber,-8} * {item.Balance.ToString("N2"),-13} * {item.Currency,-4} * ");
                    Console.WriteLine("******************************************************************************");
                }
                Console.ReadKey();
            }
        }


    }
}
