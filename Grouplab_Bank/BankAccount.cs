namespace Grouplab_Bank
{
    internal class BankAccount
    {
        public User? Owner { get; set; }
        public string? AccountNumber { get; set; }
        public decimal Balance { get; set; } = 0M;
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
    }
}
