using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class EtcMorden : BaseEthSimilarCoin
    {
        protected override string Address { get; } = "0x26588a9301b0428d95e6fc3a5024fce8bec12d51";
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMorden;
    }
}