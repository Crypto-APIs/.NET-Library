using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetInfosByBlockHash
{
    [TestClass]
    public class BtcMain : BaseBtcSimilarCoin
    {
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Btc;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Mainnet;
        protected override string BlockHash { get; } = "0000000000000000002647c65b97083eacc60466990151cfe08e6cc95175ee1b";
    }
}