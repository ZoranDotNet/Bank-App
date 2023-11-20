namespace Grouplab_Bank
{
    internal partial class User
    {
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool Admin { get; set; } = false;
        public int FailedLogin { get; set; } = 0;
        public bool IsLocked { get; set; } = false;
        public List<BankAccount>? BankAccounts { get; set; }

        public User()
        {

        }

        public User(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = password;
            BankAccounts = new List<BankAccount>();
        }

        public User(string name, string username, string password, bool admin)
        {
            Name = name;
            Username = username;
            Password = password;
            Admin = admin;
            BankAccounts = new List<BankAccount>();
        }

        private decimal CalculateInterest(double interestRate, decimal amount)
        {
            decimal interestToPay = amount * Convert.ToDecimal(interestRate) / 100;
            return interestToPay;
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
            TransactionType type = TransactionType.Deposit;
            while (!decimal.TryParse(Console.ReadLine(), out depositAmount))
            {
                Console.WriteLine("Try again...");
            }

            if (selectedAccount.InterestRate > 0)
            {
                decimal interestToPay = CalculateInterest(selectedAccount.InterestRate, depositAmount);
                Console.WriteLine($"The interest on your Savings Account will be {interestToPay.ToString("N2")} {selectedAccount.Currency} / year");
                Console.ReadKey();
            }

            if (selectedAccount != null)
            {
                selectedAccount.Balance += depositAmount;
                AddTransaction(selectedAccount, type, depositAmount);
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
            TransactionType typeFrom = TransactionType.Transfer_From;
            TransactionType typeTo = TransactionType.Transfer_To;
            Utilities.DisplayLogo();
            if (user.BankAccounts.Count < 2)
            {
                Utilities.DisplayLogo();
                Console.WriteLine("\nYou need at least 2 Accounts to make a Transfer");
                Console.ReadKey();
                return;
            }
            else
            {
                Utilities.DisplayLogo();
                Console.WriteLine("\n\nWich Account do you want to Transfer From ");
                BankAccount accountNrFrom = Menu.SelectAccount(user);

                Utilities.DisplayLogo();
                Console.WriteLine("Wich Account do you want to Transfer To ");
                BankAccount accountNrTo = Menu.SelectAccount(user);

                Utilities.DisplayLogo();
                Console.WriteLine("How much do You want to Transfer ");
                decimal amount;

                while (!decimal.TryParse(Console.ReadLine(), out amount))
                {
                    Console.Write("Try again.. ");
                }
                if (accountNrFrom != null && accountNrTo != null)
                {
                    if (accountNrFrom.Currency == Currencies.Sek && accountNrTo.Currency == Currencies.Euro)
                    {
                        decimal newAmount = MakeExchange(Currencies.Sek, amount);
                        if (accountNrFrom.Balance >= amount)
                        {
                            accountNrFrom.Balance -= amount;

                            accountNrTo.Balance += newAmount;
                            AddTransaction(accountNrFrom, typeFrom, amount);
                            AddTransaction(accountNrTo, typeTo, newAmount);

                            Utilities.DisplayLogo();
                            Console.WriteLine($"Successful transfer, {accountNrFrom.AccountNumber} transferred to {accountNrTo.AccountNumber}");
                            Console.ReadKey();
                        }
                        else
                        {
                            Utilities.DisplayLogo();
                            Console.WriteLine("You do not have sufficient funds in your account");
                            Console.ReadKey();
                        }

                    }
                    else if (accountNrFrom.Currency == Currencies.Euro && accountNrTo.Currency == Currencies.Sek)
                    {
                        decimal newAmount = MakeExchange(Currencies.Euro, amount);
                        if (accountNrFrom.Balance >= amount)
                        {
                            accountNrFrom.Balance -= amount;

                            accountNrTo.Balance += newAmount;
                            AddTransaction(accountNrFrom, typeFrom, amount);
                            AddTransaction(accountNrTo, typeTo, newAmount);

                            Utilities.DisplayLogo();
                            Console.WriteLine($"Successful transfer, {accountNrFrom.AccountNumber} transferred to {accountNrTo.AccountNumber}");
                            Console.ReadKey();
                        }
                        else
                        {
                            Utilities.DisplayLogo();
                            Console.WriteLine("You do not have sufficient funds in your account");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        if (accountNrFrom.Balance >= amount)
                        {
                            accountNrFrom.Balance -= amount;

                            accountNrTo.Balance += amount;
                            AddTransaction(accountNrFrom, typeFrom, amount);
                            AddTransaction(accountNrTo, typeTo, amount);

                            Utilities.DisplayLogo();
                            Console.WriteLine($"Successful transfer, {accountNrFrom.AccountNumber} transferred to {accountNrTo.AccountNumber}");
                            Console.ReadKey();
                        }
                        else
                        {
                            Utilities.DisplayLogo();
                            Console.WriteLine("You do not have sufficient funds in your account");
                            Console.ReadKey();
                        }
                    }




                }

            }
        }
        public void MakeExternalTransfer(User userFrom, User userTo, string account)
        {


            if (userFrom.BankAccounts == null)
            {
                Utilities.DisplayLogo();
                Console.WriteLine("You have no accounts:");
            }
            else
            {
                if (userFrom.BankAccounts.Count > 1)
                {
                    Utilities.DisplayLogo();
                    Console.WriteLine("\n\nWich Account do you want to Transfer From ");
                }
                Utilities.DisplayLogo();
                BankAccount accountNrFrom = Menu.SelectAccount(userFrom);
                Utilities.DisplayLogo();
                Console.WriteLine("How much do You want to Transfer ");

                decimal amount;
                while (!decimal.TryParse(Console.ReadLine(), out amount))
                {
                    Console.Write("Try again.. ");
                }

                var accountNrTo = userTo.BankAccounts.FirstOrDefault(x => x.AccountNumber == account);
                TransactionType typeFrom = TransactionType.Transfer_From;
                TransactionType typrTo = TransactionType.Transfer_To;

                if (accountNrFrom != null && accountNrTo != null)
                {
                    if (accountNrFrom.Balance > amount)
                    {
                        accountNrFrom.Balance -= amount;
                        accountNrTo.Balance += amount;
                        AddTransaction(accountNrFrom, typeFrom, amount);
                        AddTransaction(accountNrTo, typrTo, amount);
                    }
                    else
                    {
                        Utilities.DisplayLogo();
                        Console.WriteLine("You dont have sufficient funds in your Account");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Utilities.DisplayLogo();
                    Console.WriteLine("Could not find the Account");
                    Console.ReadKey();
                }
            }
        }
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
                    Console.WriteLine($"* AccountNr: {item.AccountNumber,-6} ** {item.Balance.ToString("N2"),-13} ** {item.Currency,-4}  ");
                    Console.WriteLine("************************************************");
                }
                Console.ReadKey();
            }
        }
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

                Utilities.DisplayLogo();
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
                    AddTransaction(selectedAccount, type, withdrawAmount);
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
        public void GetTransactionHistory(User user)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            if (user.BankAccounts.Count == 0)
            {
                Console.WriteLine("You have no BankAccount!");
                Console.ReadKey();
                return;
            }
            // we loop users BankAccounts and then loop all Transactions on every account.
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

            //This makes it look like a negative number if it is withdraw or transfer from.
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
        public decimal MakeExchange(Currencies curFrom, decimal amount)
        {
            double exchangeRate = 0;
            decimal newAmount;
            double sek = 0;
            double euro = 0;
            foreach (var item in Utilities.rates)
            {
                sek = item.Sek;
                euro = item.Euro;
            }

            //This is from Sek to Euro
            if (curFrom == Currencies.Sek)
            {
                exchangeRate = sek / euro;
                newAmount = amount * Convert.ToDecimal(exchangeRate);
                return newAmount;
            }
            else //This is Euro to Sek
            {
                exchangeRate = euro * sek;
                newAmount = amount * Convert.ToDecimal(exchangeRate);
                return newAmount;
            }

        }
        public void AdjustExchangeRate(User user)
        {
            if (user.Admin == true)
            {
                Utilities.DisplayLogo();
                Console.WriteLine("Adjust Exchange Rates");
                Console.WriteLine($"Current Rates: \nSEK = {Utilities.rates[0].SekToEuro} EUR\nEUR = {Utilities.rates[0].EuroToSek} SEK");
                switch (Menu.BankMenu("Set SEK Rate", "Set EUR Rate"))
                {
                    case 1:
                        Utilities.DisplayLogo();
                        Console.WriteLine($"SEK to EUR rate: {Utilities.rates[0].SekToEuro}");
                        double newSekRate;
                        while (!double.TryParse(Console.ReadLine(), out newSekRate))
                        {
                            Utilities.DisplayLogo();
                            Console.WriteLine("Try again...");
                            Console.ReadKey();
                        }
                        ExchangeRate sekRate = Utilities.rates[0];
                        sekRate.EuroToSek = 1 / newSekRate;
                        sekRate.SekToEuro = newSekRate;
                        Utilities.rates[0] = sekRate;
                        break;
                    case 2:
                        Utilities.DisplayLogo();
                        Console.WriteLine($"EUR to SEK rate: {Utilities.rates[0].EuroToSek}");
                        double newEurRate;
                        while (!double.TryParse(Console.ReadLine(), out newEurRate))
                        {
                            Utilities.DisplayLogo();
                            Console.WriteLine("Try again...");
                            Console.ReadKey();
                        }
                        ExchangeRate eurRate = Utilities.rates[0];
                        eurRate.SekToEuro = 1 / newEurRate;
                        eurRate.EuroToSek = newEurRate;
                        Utilities.rates[0] = eurRate;
                        break;
                }
            }
            else
            {
                Utilities.DisplayLogo();
                Console.WriteLine("Insufficient privileges");
            }
        }
    }
}
