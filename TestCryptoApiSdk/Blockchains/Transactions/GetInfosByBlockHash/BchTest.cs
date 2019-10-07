using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Transactions.GetInfosByBlockHash
{
    [TestClass]
    public class BchTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BchTestNet;
        protected override string BlockHash { get; } = "00000000007a4fdfeb39ef933a0e75aece6e399c33cc93be453ddce832a22482";
    }
}