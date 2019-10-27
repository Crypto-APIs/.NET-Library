using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.CreateTransactionPasswordWithGas
{
    [Ignore] // todo: temporarily ignored
    [TestClass]
    public class EtcMain : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMainNet;
        protected override string FromAddress { get; } = Features.CorrectAddress.EtcMainNet;
        protected override string ToAddress { get; } = Features.CorrectAddress2.EtcMainNet;
        protected override double Value { get; } = 0.12;
    }
}