namespace Grouplab_Bank
{
    internal class ExchangeRate
    {
        public static double Sek { get; set; } = 1;
        public static double Euro { get; set; } = 10.78;

        public ExchangeRate(double sek, double euro)
        {
            Sek = sek;
            Euro = euro;
        }
    }
}
