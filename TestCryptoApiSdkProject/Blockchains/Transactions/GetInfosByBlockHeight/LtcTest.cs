using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetInfosByBlockHeight
{
    [TestClass]
    public class LtcTest : BaseBtcSimilarCoin
    {
        protected override int BlockHeight { get; } = 1072866;
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Ltc;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Testnet;
    }
}