namespace Grouplab_Bank
{
    internal class ExchangeRate
    {
        public double SekToEuro { get; set; }
        public double EuroToSek { get; set; }

        public ExchangeRate(double sekToEuro, double euroToSek)
        {
            SekToEuro = sekToEuro;
            EuroToSek = euroToSek;
        }
    }
}
