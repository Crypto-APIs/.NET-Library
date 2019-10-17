using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.MultisignatureAddress
{
    [TestClass]
    public class DashTest : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = "mho4jHBcrNCncKt38trJahXakuaBnS7LK5";
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DashTestNet;
    }
}