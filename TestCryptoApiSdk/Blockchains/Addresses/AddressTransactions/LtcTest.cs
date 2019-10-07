using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class LtcTest : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = "n28CWww8GCm5gQszt77RDKDmomkh48yAS7";
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.LtcTestNet;
    }
}