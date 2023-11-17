namespace Grouplab_Bank
{
    internal partial class BankAccount
    {
        public User? Owner { get; set; }
        public string? AccountNumber { get; set; }
        public decimal Balance { get; set; } = 0;
        public List<Transaction>? Transactions { get; set; }
        public Currencies Currency { get; set; } = Currencies.Sek;
        public double InterestRate { get; set; } = 0;

        public BankAccount()
        {

        }
        public BankAccount(User owner, string accountNumber, decimal balance)
        {
            Owner = owner;
            AccountNumber = accountNumber;
            Balance = balance;
            Transactions = new List<Transaction>();
        }
        public BankAccount(User owner, string accountNumber, decimal balance, double interestRate)
        {
            Owner = owner;
            AccountNumber = accountNumber;
            Balance = balance;
            Transactions = new List<Transaction>();
            InterestRate = interestRate;
        }

        public BankAccount(User owner, string accountNumber, decimal balance, Currencies currency)
        {
            Owner = owner;
            AccountNumber = accountNumber;
            Balance = balance;
            Transactions = new List<Transaction>();
            Currency = currency;
        }

        private decimal CalculateInterest(double interestRate, decimal amount)
        {
            decimal interestToPay = amount * Convert.ToDecimal(interestRate) / 100;
            return interestToPay;
        }

        public void AddAccount(User user)
        {
            Random random = new Random();
            Utilities.DisplayLogo();
            if (user.BankAccounts.Count >= 5)
            {
                Utilities.DisplayLogo();
                Console.WriteLine("This Bank only allow a maximum of 5 BankAccounts");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("What kind of account do you want to open? please choose 1 or 2");

                switch (Menu.BankMenu("Account", "Savings Account"))
                {
                    case 1:
                        string accountNr = Convert.ToString(random.Next(100000, 999999));
                        BankAccount bankAccount = new BankAccount(Owner = user, AccountNumber = accountNr, Balance = 0);
                        if (user.BankAccounts.Count >= 5)
                        {
                            Utilities.DisplayLogo();
                            Console.WriteLine("This Bank only allow a maximum of 5 BankAccounts");
                            Console.ReadKey();
                        }
                        else
                        {
                            Utilities.DisplayLogo();
                            user.BankAccounts.Add(bankAccount);
                            Console.WriteLine("New BankAccount approved");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        Utilities.DisplayLogo();
                        Console.WriteLine("How long will you save for?");
                        double interestRate = 0.0;
                        switch (Menu.BankMenu("1 year, 3% rate", "3 years, 5% rate", "3 years, 5% rate"))
                        {
                            case 1:
                                interestRate = 3.0;
                                break;
                            case 2:
                                interestRate = 5.0;
                                break;
                            case 3:
                                interestRate = 7.0;
                                break;
                        }
                        string saveAccount = Convert.ToString(random.Next(100000, 999999));
                        BankAccount savingsAccount = new BankAccount(Owner = user, AccountNumber = saveAccount, Balance = 0, InterestRate = interestRate);
                        user.BankAccounts.Add(savingsAccount);
                        Utilities.DisplayLogo();
                        Console.WriteLine($"New Savings Account approved with {interestRate}% rate");
                        Console.ReadKey();
                        break;
                }

            }

        }

        //This Method just print out all accountNumbers
        private void ListAllBankAccounts(User user)
        {
            if (user.BankAccounts.Count > 0)
            {
                Console.WriteLine("Your Accounts: ");

                foreach (var item in user.BankAccounts)
                {
                    Console.WriteLine(item.AccountNumber);
                }
            }
            else
            {
                Console.WriteLine("You have no BankAccount");
                Console.ReadKey();
            }
        }

        public void MakeDeposit(User user)
        {
            if (user.BankAccounts.Count == 0)
            {
                Console.WriteLine("\nYou have no BankAccount ");
                Console.ReadKey();
                return;
            }

            Utilities.DisplayLogo();
            Console.Write("\nWich Account do you want to make your Deposit To\n\n");
            BankAccount selectedAccount = Menu.SelectAccount(user);
            Utilities.DisplayLogo();
            Console.WriteLine("\nHow much do you want to Deposit");
            decimal depositAmount;
            while (!decimal.TryParse(Console.ReadLine(), out depositAmount))
            {
                Console.WriteLine("Try again...");
            }

            if (selectedAccount.InterestRate > 0)
            {
                decimal interestToPay = CalculateInterest(selectedAccount.InterestRate, depositAmount);
                Console.WriteLine($"The interest on your Savings Account will be {interestToPay} {selectedAccount.Currency} / year");
                Console.ReadKey();
            }

            if (selectedAccount != null)
            {
                selectedAccount.Balance += depositAmount;
            }
            else
            {
                Console.WriteLine("Could not find Account");
                Console.ReadKey();
            }
        }

        public void GetAccountInfo(User user)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (user.BankAccounts.Count == 0)
            {
                Console.WriteLine("You have no BankAccount");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("******************************************************************************");
                Console.WriteLine("* AccountNr **    Balance     **  Currency  **  Interest %  **    Owner      *");
                Console.WriteLine("******************************************************************************");
                foreach (var item in user.BankAccounts)
                {
                    Console.WriteLine($"*  {item.AccountNumber,-8} **  {item.Balance.ToString("N2"),-13} **    {item.Currency,-7} **       {item.InterestRate,-6} **  {item.Owner.Name,-10}   *");
                    Console.WriteLine("******************************************************************************");
                }

                Console.ReadKey();
            }
        }

        public void MakeTransfer(User user)
        {
            Console.WriteLine("1 for Transfer to your own Account");
            Console.WriteLine("2 for Transfer to someone elses Account");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                if (user.BankAccounts.Count < 2)
                {
                    Console.WriteLine("\nYou need at least 2 Accounts to make a Transfer");
                    Console.ReadKey();
                    return;
                }


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

                //if we find both accounts we proceed otherwisw back to menu
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

            else
            {
                Console.WriteLine("Invalid choice ");
                Console.ReadKey();
            }




        }

        public void MakeExternalTransfer(User userFrom, User userTo, string account)
        {
            ListAllBankAccounts(userFrom);

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
            var accountFrom = userFrom.BankAccounts.FirstOrDefault(x => x.AccountNumber == accountNrFrom);


            Console.WriteLine("Wich AccounNumber do you want to Trasfer To");
            string accountNr = Console.ReadLine();

            // needs to make a method to find AccountNr that matches another user

        }
    }
}
