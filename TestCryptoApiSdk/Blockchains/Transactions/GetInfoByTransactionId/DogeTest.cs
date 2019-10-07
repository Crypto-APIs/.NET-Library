using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Transactions.GetInfoByTransactionId
{
    [TestClass]
    public class DogeTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DogeTestNet;
        protected override string TransactionId { get; } = "fd9896891d9ca6334407d1b20068f3546758d3175177573eade1f47adc58e78a";
    }
}