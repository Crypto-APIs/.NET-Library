using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Info.GetBlockHeight
{
    [TestClass]
    public class BchMain : BaseBtcSimilarCoin
    {
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Bch;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Mainnet;
        protected override int BlockHeight { get; } = 5;
    }
}