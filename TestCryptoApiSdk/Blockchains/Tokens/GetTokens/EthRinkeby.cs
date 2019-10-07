using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Tokens.GetTokens
{
    [TestClass]
    public class EthRinkeby : BaseEthSimilarCoin
    {
        [TestMethod]
        public override void MainTest()
        {

        }

        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthRinkeby;
        protected override string Address { get; } = "0x2b5634c42055806a59e9107ed44d43c426e58258 ";
    }
}