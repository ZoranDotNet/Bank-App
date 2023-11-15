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

        public void AddAccount(User user)
        {
            Random random = new Random();
            Utilities.DisplayLogo();
            Console.WriteLine("What kind of account do you want to open? please choose 1 or 2");
            Console.WriteLine("1. Account");
            Console.WriteLine("2. Savings Account");

            string answer = Console.ReadLine();

            if (answer == "1")
            {

                string accountNr = Convert.ToString(random.Next(100000, 999999));
                BankAccount bankAccount = new BankAccount(Owner = user, AccountNumber = accountNr, Balance = 0);
                user.BankAccounts.Add(bankAccount);

                Console.WriteLine("New BankAccount approved");
                Console.ReadKey();
            }
            else if (answer == "2")
            {

                Console.WriteLine("How long will you save for? please choose between 1 to 3");
                Console.WriteLine("1. 1 year, 3% rate");
                Console.WriteLine("2. 3 years, 5% rate");
                Console.WriteLine("3. 5 years, 7% rate");
                string answersaving = Console.ReadLine();
                double interestRate = 0.0;

                if (answersaving == "1")
                {
                    interestRate = 3.0;
                }
                else if (answersaving == "2")
                {
                    interestRate = 5.0;
                }
                else if (answersaving == "3")
                {
                    interestRate = 7.0;
                }
                else
                {
                    Console.WriteLine("Invalid answer, please choose option 1 to 3");
                    return;
                }
                string saveAccount = Convert.ToString(random.Next(100000, 99999));
                BankAccount savingsAccount = new BankAccount(Owner = user, AccountNumber = saveAccount, Balance = 0, InterestRate = interestRate);
                user.BankAccounts.Add(savingsAccount);
                Console.WriteLine($"New Savings Account approved with {interestRate}% rate");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Invalid answer, please choose option 1 or 2");
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

            //if user have more than 1 bankaccount
            if (user.BankAccounts.Count > 1)
            {
                Utilities.DisplayLogo();
                ListAllBankAccounts(user);

                Console.Write("\nWich Account do you want to make your Deposit To ");
                string userAccountInput = Console.ReadLine();

                Console.WriteLine("\nHow much do you want to Deposit");
                decimal depositAmount;
                while (!decimal.TryParse(Console.ReadLine(), out depositAmount))
                {
                    Console.WriteLine("Try again...");
                }
                //We find the matching AccountNumber from userinput
                var selectedAccount = user.BankAccounts.FirstOrDefault(x => x.AccountNumber == userAccountInput);

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
            else
            {
                Console.Write("\nHow much would You like to Deposit. ");
                decimal amount;

                while (!decimal.TryParse(Console.ReadLine(), out amount))
                {
                    Console.WriteLine("Try again...");
                }
                //gives us the first account in the list(should only be 1)
                var account = user.BankAccounts.FirstOrDefault();

                if (account != null)
                {
                    account.Balance += amount;
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

    }
}
