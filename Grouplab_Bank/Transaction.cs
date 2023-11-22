namespace Grouplab_Bank
{
    internal class Transaction
    {
        public DateTime Date { get; set; }
        public BankAccount? Account { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }

        public Transaction()
        {

        }
        public Transaction(DateTime date, BankAccount account, decimal amount, TransactionType type)
        {
            Date = date;
            Account = account;
            Amount = amount;
            Type = type;
        }
    }
}
