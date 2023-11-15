namespace Grouplab_Bank
{
    internal partial class BankAccount
    {
        public void MakeTransfer(User user)
        {
            ListAllBankAccounts(user);

            Console.WriteLine("\n\nWich Account do you want to Transfer From ");
            string accountNrFrom = Console.ReadLine();
            Console.WriteLine("Wich Account do you want to Transfer To ");
            string accountNrTo = Console.ReadLine();
            Console.WriteLine("How much do You want to Transfer ");
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.Write("Try again.. ");
            }
            //finding users Account to Transfer from
            var accountFrom = user.BankAccounts.FirstOrDefault(x => x.AccountNumber == accountNrFrom);
            // finding users Account to Transfer to
            var accountTo = user.BankAccounts.FirstOrDefault(x => x.AccountNumber == accountNrTo);

            if (accountFrom != null && accountTo != null)
            {
                if (accountFrom.Balance >= amount)
                {
                    accountFrom.Balance -= amount;

                    accountTo.Balance += amount;
                }
                else
                {
                    Console.WriteLine("You do not have sufficient funds in your account");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Could not find your account ");
                Console.ReadKey();
            }
        }

        public void MakeExternalTransfer(User user)
        {
            ListAllBankAccounts(user);

            Console.WriteLine("\n\nWich Account do you want to Transfer From ");
            string accountNrFrom = Console.ReadLine();
            Console.WriteLine("Wich Account do you want to Transfer To ");
            string accountNrTo = Console.ReadLine();
            Console.WriteLine("How much do You want to Transfer ");
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.Write("Try again.. ");
            }

            //finding users Account to Transfer from
            var accountFrom = user.BankAccounts.FirstOrDefault(x => x.AccountNumber == accountNrFrom);

            // needs to make a method to find AccountNr that matches another user


        }


    }
}
