using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Tokens.GetTokens
{
    [TestClass]
    public class EthRinkeby : BaseEthSimilarCoin
    {
        [TestMethod]
        public override void MainTest()
        {

        }

        protected override EthSimilarCoin Coin { get; } = EthSimilarCoin.Eth;
        protected override EthSimilarNetwork Network { get; } = EthSimilarNetwork.Rinkeby;
        protected override string Address { get; } = "0x2b5634c42055806a59e9107ed44d43c426e58258 ";
    }
}