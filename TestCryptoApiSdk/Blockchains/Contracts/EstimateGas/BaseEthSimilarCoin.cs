using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Contracts.EstimateGas
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Contract.EstimateGas<EthEstimateGasContractResponse>(NetworkCoin);

            AssertNullErrorMessage(response);
            Assert.IsTrue(response.Payload.GasLimit > 0, $"{response.Payload.GasLimit} must be greater than 0");
            Assert.IsTrue(response.Payload.GasPrice > 0, $"{response.Payload.GasPrice} must be greater than 0");
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}