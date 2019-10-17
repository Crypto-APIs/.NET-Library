using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Info.GetInfo
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Info.GetInfo<GetBtcInfoResponse>(NetworkCoin);

            AssertNullErrorMessage(response);
            Assert.AreEqual(NetworkCoin.Coin.ToString(), response.Info.Currency, true, 
                "'Currency' is wrong");
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}