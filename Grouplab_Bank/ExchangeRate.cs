namespace Grouplab_Bank
{
    internal class ExchangeRate
    {
        public Currencies Name { get; set; }
        public double Value { get; set; }

        public ExchangeRate(Currencies name, double value)
        {
            Name = name;
            Value = value;
        }
    }
}
