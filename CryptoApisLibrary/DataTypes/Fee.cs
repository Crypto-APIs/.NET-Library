namespace CryptoApisLibrary.DataTypes
{
    public class Fee
    {
        public Fee(string address, double value)
        {
            Address = address;
            Value = value;
        }

        public Fee(double value)
        {
            Value = value;
        }

        public string Address { get; }
        public double Value { get; }
    }
}