using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetInfoByTransactionId
{
    [TestClass]
    public class DashTest : BaseBtcSimilarCoin
    {
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Dash;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Testnet;
        protected override string TransactionId { get; } = "066100ef7304e0467aeac07b8f8866ddb30e6a0b8c935bc79f0870a081a88977";
    }
}