using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public class LtcTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.LtcTestNet;
        protected override string BlockHash { get; } = "1f2ac66307496209107b7ed45d13423741be50389b718b549f964d8ddcdec0a9";
    }
}