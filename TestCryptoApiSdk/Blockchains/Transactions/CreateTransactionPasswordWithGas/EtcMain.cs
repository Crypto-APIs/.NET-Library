using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.CreateTransactionPasswordWithGas
{
    [Ignore] // todo: temporarily ignored
    [TestClass]
    public class EtcMain : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMainNet;
        protected override string FromAddress { get; } = "0x1c0fa194a9d3b44313dcd849f3c6be6ad270a0a4";
        protected override string ToAddress { get; } = "0x461d05612a9fea4a9ed118dbf21ebb81ef0dac3c";
        protected override double Value { get; } = 0.12;
    }
}