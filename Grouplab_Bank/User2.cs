using System.Xml.Schema;

namespace Grouplab_Bank
{
    internal partial class User
    {
       
        private decimal GetInterest(decimal loan,decimal interestRate = 0.05m)
        {
            decimal interest = loan * interestRate;
            return interest;
        }
        public void LoanMoney(User user)
        {
           
            if (user.BankAccounts.Count == 0)
            {
                Utilities.DisplayLogo();
                Console.WriteLine("\nYou have no BankAccount ");
                Console.ReadKey();
                return;
            }

            decimal totalAmount = 0;

            foreach (var item in user.BankAccounts)
            {
                totalAmount += item.Balance;
            }

            decimal maxLoanAmount = totalAmount * 5;
            Console.WriteLine($"You can borrow up to {maxLoanAmount} sek.");
            Console.WriteLine("How much do you want to borrow?");
            decimal loan;
           
            TransactionType type = TransactionType.Loan;
            while (!decimal.TryParse(Console.ReadLine(), out loan))
            {
                Console.Write("Try again.. ");
                Console.ReadKey();
                
            }
            
            if (maxLoanAmount < loan)
            {
                Console.WriteLine("You cant loan that much money.");
                Console.ReadKey();
                return;
            }
            else
            {
                decimal interest = GetInterest(loan);
                Console.WriteLine($"You have to pay {interest} kr in interest on your loan yearly");
                Console.ReadKey();
                
                Utilities.DisplayLogo();
                if (user.BankAccounts.Count > 1)
                {
                    Console.WriteLine("Choose bankaccount to wich your loan will be deposited.");
                    Console.ReadKey();
                }

                BankAccount selectedAccount = Menu.SelectAccount(user);

                selectedAccount.Balance += loan;
                Console.WriteLine($"Your {loan} kr loan has been approved and deposited to account {selectedAccount.AccountNumber}");
                Console.ReadKey();

                AddTransaction(selectedAccount,type,loan);








            }
        }
    }
}
