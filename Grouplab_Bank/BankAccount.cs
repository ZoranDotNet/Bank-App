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

        public BankAccount AddAccount(User user)
        {
            Random random = new Random();
            Utilities.DisplayLogo();
            if (user.BankAccounts.Count >= 5)
            {
                Utilities.DisplayLogo();
                Console.WriteLine("This Bank only allow a maximum of 5 BankAccounts");
                Console.ReadKey();
                return null;
            }
            else
            {
                Console.WriteLine("What kind of account do you want to open? please choose 1 or 2");

                switch (Menu.BankMenu("Bank Account", "Savings Account", "Euro Account"))
                {
                    case 1:
                        string accountNr = Convert.ToString(random.Next(100000, 999999));
                        BankAccount bankAccount = new BankAccount(Owner = user, AccountNumber = accountNr, Balance = 0);
                        Utilities.DisplayLogo();
                        Console.WriteLine("New Bank Account approved");
                        Console.ReadKey();
                        return bankAccount;

                    case 2:
                        Utilities.DisplayLogo();
                        Console.WriteLine("How long will you save for?");
                        double interestRate = 0.0;
                        switch (Menu.BankMenu("1 year, 3.5% rate", "3 years, 5% rate", "5 years, 7.5% rate"))
                        {
                            case 1:
                                interestRate = 3.5;
                                break;
                            case 2:
                                interestRate = 5.0;
                                break;
                            case 3:
                                interestRate = 7.5;
                                break;
                        }
                        string saveAccount = Convert.ToString(random.Next(100000, 999999));
                        BankAccount savingsAccount = new BankAccount(Owner = user, AccountNumber = saveAccount, Balance = 0, InterestRate = interestRate);
                        Utilities.DisplayLogo();
                        Console.WriteLine($"New Savings Account approved with {interestRate}% rate");
                        Console.ReadKey();
                        return savingsAccount;
                    case 3:
                        string euroAccountnr = Convert.ToString(random.Next(100000, 999999));
                        BankAccount euroAccount = new BankAccount(Owner = user, AccountNumber = euroAccountnr, Balance = 0, Currency = Currencies.Euro);
                        Utilities.DisplayLogo();
                        Console.WriteLine($"New Euro Account aprroved.");
                        Console.ReadKey();
                        return euroAccount;
                }
                return null;
            }
        }
    }
}
