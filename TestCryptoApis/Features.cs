using CryptoApisLibrary.DataTypes;

namespace TestCryptoApis
{
    internal static class Features
    {
        public static Exchange Bittrex { get; } = new Exchange("5b1ea9d21090c200146f7366");
        public static Exchange Binance { get; } = new Exchange("5b1ea9d21090c200146f7362");
        public static Exchange Bitstamp { get; } = new Exchange("5b1ea9d21090c200146f7364");
        public static Exchange Poloniex { get; } = new Exchange("5b1ea9d21090c200146f7367");
        public static Exchange UnexistingExchange { get; } = new Exchange("QWE'EWQ");

        public static Asset Btc { get; } = new Asset("5b1ea92e584bf50020130612");
        public static Asset Usd { get; } = new Asset("5b1ea92e584bf50020130615");
        public static Asset Ltc { get; } = new Asset("5b1ea92e584bf50020130616");
        public static Asset Eth { get; } = new Asset("5b755dacd5dd99000b3d92b2");
        public static Asset Dash { get; } = new Asset("5b1ea92e584bf50020130620");
        public static Asset Doge { get; } = new Asset("5b1ea92e584bf50020130626");
        public static Asset Bch { get; } = new Asset("5b1ea92e584bf5002013061c");
        public static Asset UnexistingAsset { get; } = new Asset("QWE'EWQ");

        public static Symbol BtcLtc { get; } = new Symbol { Id = "5bfc325d9c40a100014db900" };
        public static Symbol BtcBch { get; } = new Symbol { Id = "5bfc325f9c40a100014db9b0" };
        public static Symbol UsdBtc { get; } = new Symbol { Id = "5bfc325f9c40a100014db9eb" };
        public static Symbol EthLtc { get; } = new Symbol { Id = "5bfc325e9c40a100014db98b" };
        public static Symbol UnexistingSymbol { get; } = new Symbol { Id = "QWE'EWQ" };
    }
}