using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public class DashTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DashTestNet;
        protected override string BlockHash { get; } = "000000000c845bf0cfb24f501db65f171a200c8de126c3c4698688a1128189f9";
    }
}