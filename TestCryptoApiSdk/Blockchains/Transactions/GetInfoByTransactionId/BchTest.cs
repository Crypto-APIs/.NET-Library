using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Transactions.GetInfoByTransactionId
{
    [TestClass]
    public class BchTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BchTestNet;
        protected override string TransactionId { get; } = "066100ef7304e0467aeac07b8f8866ddb30e6a0b8c935bc79f0870a081a88977";
    }
}