using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.CreateTransactionPasswordWithGas
{
    [Ignore] // todo: temporarily ignored
    [TestClass]
    public class EthMain : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthMainNet;
        protected override string FromAddress { get; } = Features.CorrectAddress.EthMainNet;
        protected override string ToAddress { get; } = Features.CorrectAddress2.EthMainNet;
        protected override double Value { get; } = 0.12;
    }
}