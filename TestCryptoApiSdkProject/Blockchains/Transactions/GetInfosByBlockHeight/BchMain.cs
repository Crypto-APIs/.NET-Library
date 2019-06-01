using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetInfosByBlockHeight
{
    [TestClass]
    public class BchMain : BaseBtcSimilarCoin
    {
        protected override int BlockHeight { get; } = 80001;
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Bch;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Mainnet;
    }
}