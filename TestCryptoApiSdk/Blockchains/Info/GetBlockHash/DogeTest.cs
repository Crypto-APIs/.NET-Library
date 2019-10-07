using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public class DogeTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DogeTestNet;
        protected override string BlockHash { get; } = "ea11f3fdb69e2006beb2c951ff6d7ce6e01a599df7f5d8a61c85a75cd4ac5161";
    }
}