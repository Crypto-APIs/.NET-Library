using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Tokens.GetTokens
{
    [TestClass]
    public class EtcMorden : BaseEthSimilarCoin
    {
        [TestMethod]
        public override void MainTest()
        {
            
        }

        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMorden;
        protected override string Address { get; } = "0x26588a9301b0428d95e6fc3a5024fce8bec12d51";
    }
}