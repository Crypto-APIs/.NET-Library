using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public class LtcTest : BaseBtcSimilarCoin
    {
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Ltc;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Testnet;
        protected override string BlockHash { get; } = "1f2ac66307496209107b7ed45d13423741be50389b718b549f964d8ddcdec0a9";
    }
}