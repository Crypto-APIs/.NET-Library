using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Transactions.CreateTransactionPassword
{
    [Ignore] // todo: temporarily ignored
    [TestClass]
    public class EthMain : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthMainNet;
        protected override string FromAddress { get; } = ""; // todo: need corrected addresses
        protected override string ToAddress { get; } = "";
        protected override double Value { get; } = 0.12;
    }
}