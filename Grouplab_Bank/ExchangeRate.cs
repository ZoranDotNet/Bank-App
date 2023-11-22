namespace Grouplab_Bank
{
    internal class ExchangeRate
    {
        public string Name { get; set; }
        public double Value { get; set; }

        public ExchangeRate(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
}
