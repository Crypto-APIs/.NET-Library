using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Contracts.EstimateGas
{
    [TestClass]
    public class EthSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin)
        {
            var response = Manager.Blockchains.Contract.EstimateGas<EthEstimateGasContractResponse>(networkCoin);

            AssertNullErrorMessage(response);
            Assert.IsTrue(response.Payload.GasLimit > 0, $"{response.Payload.GasLimit} must be greater than 0");
            Assert.IsTrue(response.Payload.GasPrice > 0, $"{response.Payload.GasPrice} must be greater than 0");
        }
    }
}