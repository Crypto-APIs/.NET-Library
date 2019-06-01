using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetInfosByBlockHash
{
    [TestClass]
    public class LtcTest : BaseBtcSimilarCoin
    {
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Ltc;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Testnet;
        protected override string BlockHash { get; } = "87414fdc60fa76810a37020c9e5d7edc394e19cca0978733442c58e2d73e1bb3";
    }
}