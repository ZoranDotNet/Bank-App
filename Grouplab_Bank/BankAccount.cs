namespace Grouplab_Bank
{
    internal class BankAccount
    {
        public User? Owner { get; set; }
        public string? AccountNumber { get; set; }
        public decimal Balance { get; set; } = 0;
        public List<Transaction>? Transactions { get; set; }

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

        public void AddAccount(User user)
        {
            Random random = new Random();
            string accountNr = Convert.ToString(random.Next(100000, 999999));
            BankAccount bankAccount = new BankAccount(Owner = user, AccountNumber = accountNr, Balance = 0);
            user.BankAccounts.Add(bankAccount);
        }

        //This Method just print out all accountNumbers
        private void ListAllBankAccounts(User user)
        {
            Console.WriteLine("Your Accounts: ");

            foreach (var item in user.BankAccounts)
            {
                Console.WriteLine(item.AccountNumber);
            }
        }

        public void MakeDeposit(User user)
        {
            //if user have more than 1 bankaccount
            if (user.BankAccounts.Count > 1)
            {
                Utilitys.Logo();
                ListAllBankAccounts(user);

                Console.WriteLine("\nWich Account do you want to make your Deposit To ");
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
                if (user.BankAccounts.Count == 0)
                {
                    Console.WriteLine("\nYou have no BankAccount ");
                }

                Utilitys.Logo();
                Console.WriteLine("\nHow much would You like to Deposit.");
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

    }
}
