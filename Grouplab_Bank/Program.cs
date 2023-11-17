namespace Grouplab_Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank();
            Menu.SetBank(bank);
            bank.Run();


        }
    }
}