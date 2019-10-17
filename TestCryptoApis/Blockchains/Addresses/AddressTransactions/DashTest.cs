using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class DashTest : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = "qznt28kfs4a6tyknu4ar7whxd2r7mwktq5l50f2pca";
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DashTestNet;
    }
}