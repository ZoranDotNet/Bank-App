using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grouplab_Bank
{
    internal partial class BankAccount
    {
        public void MakeWithdraw(User user)
        {
            if (user.BankAccounts.Count == 0)
            {
                Console.WriteLine("\nYou have no BankAccount ");
                Console.ReadKey();
                return;
            }
            if (user.BankAccounts.Count > 1)
            {
                GetBalance(user);
                Console.WriteLine("\nWich account do you want to withdraw from?");
                string thisAccount = Console.ReadLine();
                Console.WriteLine("\nEnter amount to withdraw:");
                
                decimal withdrawAmount;
                while (!decimal.TryParse(Console.ReadLine(), out withdrawAmount))
                {
                    Console.WriteLine("Try again...");
                }
                var selectedAccount = user.BankAccounts.FirstOrDefault(x => x.AccountNumber == thisAccount);
               
                if (selectedAccount != null)
                {
                    if (selectedAccount.Balance > withdrawAmount)
                    {
                        selectedAccount.Balance -= withdrawAmount;
                        Console.WriteLine($"You have successfully withdrawn {withdrawAmount} from account {selectedAccount.AccountNumber}." +
                            $"\nThe balance of account {selectedAccount.AccountNumber} is now {selectedAccount.Balance.ToString()}");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"You dont have enough money in account {selectedAccount}");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Account not found");
                    Console.ReadKey();
                }
               
            }
            else
            {
                GetBalance(user);
                Console.WriteLine("\nEnter amount to withdraw:");
                decimal amountToWithdraw;
                while (!decimal.TryParse(Console.ReadLine(),out amountToWithdraw))
                {
                    Console.WriteLine("Try again...");
                }
                var onlyAccount = user.BankAccounts.FirstOrDefault();
               
                if (onlyAccount != null)
                {
                    if (onlyAccount.Balance > amountToWithdraw)
                    {
                        onlyAccount.Balance -= amountToWithdraw;
                        Console.WriteLine($"You have successfully withdrawn {amountToWithdraw} from account {onlyAccount.AccountNumber}." +
                           $"\nThe balance of account {onlyAccount.AccountNumber} is now {onlyAccount.Balance.ToString()}");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine($"Yoy dont have enough money in account {onlyAccount.AccountNumber}");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Account not found");
                    Console.ReadKey();
                }
            }
        }
    }
}
