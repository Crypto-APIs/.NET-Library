using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Tokens.GetTokens
{
    [TestClass]
    public class EthMain : BaseEthSimilarCoin
    {
        [TestMethod]
        public override void MainTest()
        {
            
        }

        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthMainNet;
        protected override string Address { get; } = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
    }
}