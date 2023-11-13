namespace Grouplab_Bank
{
    internal class BankAccount
    {
        public User? Owner { get; set; }
        public string? AccountNumber { get; set; }
        public decimal Balance { get; set; }
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



        public void MakeDeposit(User user)
        {
            //if user have more than 1 bankaccount
            if (user.BankAccounts.Count > 1)
            {
                //List all bankaccounts and let user choose wich one to use
                //probably make a new method just to loop over all bankaccounts
            }
            else
            {
                Console.WriteLine("How much would You like to Deposit.");
                decimal input;

                while (!decimal.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Try again...");
                }
                //gives us the first account on the list
                var account = user.BankAccounts.FirstOrDefault();

                if (account == null)
                {
                    Console.WriteLine("You have no bankaccount");
                }
                else
                {
                    account.Balance += input;
                }

            }
        }

    }
}
