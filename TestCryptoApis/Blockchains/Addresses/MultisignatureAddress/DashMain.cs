using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.MultisignatureAddress
{
    [TestClass]
    public class DashMain : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = "bitcoincash:pp8skudq3x5hzw8ew7vzsw8tn4k8wxsqsv0lt0mf3g";
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DashMainNet;
    }
}