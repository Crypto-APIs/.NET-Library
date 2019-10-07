using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Transactions.GetInfoByTransactionId
{
    [TestClass]
    public class LtcTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.LtcTestNet;
        protected override string TransactionId { get; } = "7872e2e2ddd548b05821e718b88bae9f310bf696dbfe5a82ae2b7b95a70f6501";
    }
}