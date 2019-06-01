using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Contracts.EstimateGas
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Contract.EstimateGas(Coin, Network);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsTrue(response.Payload.GasLimit > 0);
            Assert.IsTrue(response.Payload.GasPrice > 0);
        }

        protected abstract EthSimilarCoin Coin { get; }
        protected abstract EthSimilarNetwork Network { get; }
    }
}