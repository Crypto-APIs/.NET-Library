using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Tokens.GetBalance
{
    [TestClass]
    public class EtcMain : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMainNet;
        protected override string Address { get; } = "0x737165b2913122aF76e05a3E6bbF2a6128484662";
        protected override string Contract { get; } = "0x1BE6D61B1103D91F7f86D47e6ca0429259A15ff0";
    }
}