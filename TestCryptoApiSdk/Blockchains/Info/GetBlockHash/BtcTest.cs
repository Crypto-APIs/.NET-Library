using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public class BtcTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BtcTestNet;
        protected override string BlockHash { get; } = "000000000000008fa830e25a3904d5c16a4e3ccee690ce5a7ef8e06237cdf593";
    }
}