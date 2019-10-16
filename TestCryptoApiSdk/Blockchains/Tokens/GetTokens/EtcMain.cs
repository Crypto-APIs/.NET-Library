using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Tokens.GetTokens
{
    [TestClass]
    public class EtcMain : BaseEthSimilarCoin
    {
        [TestMethod]
        public override void MainTest()
        {
            
        }

        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMainNet;
        protected override string Address { get; } = "0x1c0fa194a9d3b44313dcd849f3c6be6ad270a0a4";
    }
}