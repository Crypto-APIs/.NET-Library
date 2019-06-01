using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class LtcTest : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = "n28CWww8GCm5gQszt77RDKDmomkh48yAS7";
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Ltc;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Testnet;
    }
}