namespace CryptoApisSdkLibrary.DataTypes
{
    public class TransactionAddress
    {
        public TransactionAddress(string address, double value)
        {
            Address = address;
            Value = value;
        }

        public string Address { get; }
        public double Value { get; }
    }
}