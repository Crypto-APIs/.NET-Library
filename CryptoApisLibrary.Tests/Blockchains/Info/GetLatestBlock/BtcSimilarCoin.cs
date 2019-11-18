using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Info.GetLatestBlock
{
    [TestClass]
    public class BtcSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin)
        {
            var response = Manager.Blockchains.Info.GetLatestBlock<GetBtcHashInfoResponse>(networkCoin);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.HashInfo.Chainwork),
                $"'{nameof(response.HashInfo.Chainwork)}' must not be null");
        }
    }
}