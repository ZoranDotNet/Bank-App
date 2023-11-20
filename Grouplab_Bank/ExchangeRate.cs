namespace Grouplab_Bank
{
    internal class ExchangeRate
    {
        public double Sek { get; set; }
        public double Euro { get; set; }

        public ExchangeRate(double sek, double euro)
        {
            Sek = sek;
            Euro = euro;
        }
    }
}
