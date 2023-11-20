namespace Grouplab_Bank
{
    internal class ExchangeRate
    {
        public static double Sek { get; set; }
        public static double Euro { get; set; }

        public ExchangeRate(double sek, double euro)
        {
            Sek = sek;
            Euro = euro;
        }
    }
}
