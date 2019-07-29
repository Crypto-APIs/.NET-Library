using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Addresses.MultisignatureAddress
{
    [TestClass]
    public class DogeTest : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = "mho4jHBcrNCncKt38trJahXakuaBnS7LK5";
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Doge;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Testnet;
    }
}