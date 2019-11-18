using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Info.GetInfo
{
    [TestClass]
    public abstract class BtcSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin)
        {
            var response = Manager.Blockchains.Info.GetInfo<GetBtcInfoResponse>(networkCoin);

            AssertNullErrorMessage(response);
            Assert.AreEqual(networkCoin.Coin.ToString(), response.Info.Currency, true,
                "'Currency' is wrong");
        }
    }
}