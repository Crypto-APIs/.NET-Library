namespace CryptoApisLibrary.DataTypes
{
    public abstract class Network
    {
        protected Network(string value)
        {
            Value = value;
        }

        private string Value { get; }

        public override string ToString()
        {
            return Value;
        }
    }

    public class BtcSimilarNetwork : Network
    {
        public static BtcSimilarNetwork Testnet => new BtcSimilarNetwork("testnet");
        public static BtcSimilarNetwork Mainnet => new BtcSimilarNetwork("mainnet");

        private BtcSimilarNetwork(string value) : base(value)
        {
        }
    }

    public class EthSimilarNetwork : Network
    {
        public static EthSimilarNetwork Mainnet => new EthSimilarNetwork("mainnet");
        public static EthSimilarNetwork Ropsten => new EthSimilarNetwork("ropsten");
        public static EthSimilarNetwork Rinkeby => new EthSimilarNetwork("rinkeby");
        public static EthSimilarNetwork Morden => new EthSimilarNetwork("morden");

        private EthSimilarNetwork(string value) : base(value)
        {
        }
    }
}