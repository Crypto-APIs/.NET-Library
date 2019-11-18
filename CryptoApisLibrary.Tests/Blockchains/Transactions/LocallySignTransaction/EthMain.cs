using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Transactions.LocallySignTransaction
{
    [TestClass]
    public class EthMain : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthMainNet;
        protected override string FromAddress { get; } = "0x1b85a43e2e7f52e766ddfdfa2b901c42cb1201be";
        protected override string ToAddress { get; } = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
        protected override double Value { get; } = 1.212;
    }
}