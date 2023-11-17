namespace Grouplab_Bank
{
    internal partial class BankAccount
    {
        public void MakeWithdraw(User user)
        {
            if (user.BankAccounts.Count == 0)
            {
                Utilities.DisplayLogo();
                Console.WriteLine("\nYou have no BankAccount ");
                Console.ReadKey();
                return;
            }
            else
            {
                if (user.BankAccounts.Count > 1)
                {
                    Console.WriteLine("\nWich account do you want to withdraw from?");
                }
                BankAccount selectedAccount = Menu.SelectAccount(user);

                Console.WriteLine("\nEnter amount to withdraw:");
                decimal withdrawAmount;
                TransactionType type = TransactionType.Withdraw;
                while (!decimal.TryParse(Console.ReadLine(), out withdrawAmount))
                {
                    Console.WriteLine("Try again...");
                }

                if (selectedAccount.Balance > withdrawAmount)
                {
                    selectedAccount.Balance -= withdrawAmount;
                    Addtransaction(selectedAccount, type, withdrawAmount);
                    Console.WriteLine($"You have successfully withdrawn {withdrawAmount} from account {selectedAccount.AccountNumber}");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"You dont have enough money in account {selectedAccount.AccountNumber}");
                    Console.ReadKey();
                }

            }    
        }
    }
}
