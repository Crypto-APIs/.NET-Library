using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.DataTypes.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class GetExchangeRates : BaseTest
    {
        [TestMethod]
        public void TestUsdBtc()
        {
            var baseAsset = new Asset("USD");
            var quoteAsset = new Asset("Btc");
            var response = Manager.Exchanges.GetExchangeRate(baseAsset, quoteAsset);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.ExchangeRate);
            Assert.AreEqual("USD", response.ExchangeRate.BaseAssetId);
        }

        [TestMethod]
        public void TestUsdBtcTimeStamp()
        {
            var baseAsset = new Asset("USD");
            var quoteAsset = new Asset("Btc");
            var timeStamp = new DateTime(2019, 02, 03);
            var response = Manager.Exchanges.GetExchangeRate(baseAsset, quoteAsset, timeStamp);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.ExchangeRate);
        }

        [TestMethod]
        [ExpectedException(typeof(RequestException), "A BaseAsset of null was inappropriately allowed.")]
        public void TestUndefinedBaseAsset()
        {
            var quoteAsset = new Asset("Btc");
            var timeStamp = new DateTime(2019, 02, 03);
            Manager.Exchanges.GetExchangeRate(baseAsset: null, quoteAsset: quoteAsset, timeStamp: timeStamp);
        }

        [TestMethod]
        [ExpectedException(typeof(RequestException), "A QuoteAsset of null was inappropriately allowed.")]
        public void TestUndefinedQuoteAsset()
        {
            var baseAsset = new Asset("USD");
            var timeStamp = new DateTime(2019, 02, 03);
            Manager.Exchanges.GetExchangeRate(baseAsset: baseAsset, quoteAsset: null, timeStamp: timeStamp);
        }

        [TestMethod]
        public void TestIncorrectBaseAsset()
        {
            var baseAsset = new Asset("QWEEWQ");
            var quoteAsset = new Asset("Btc");
            var timeStamp = new DateTime(2019, 02, 03);
            var response = Manager.Exchanges.GetExchangeRate(baseAsset, quoteAsset, timeStamp);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Exchange rate not found for the pair", response.ErrorMessage);
            Assert.IsNull(response.ExchangeRate);
        }

        [TestMethod]
        public void TestIncorrectQuoteAsset()
        {
            var baseAsset = new Asset("USD");
            var quoteAsset = new Asset("QWEEWQ");
            var timeStamp = new DateTime(2019, 02, 03);
            var response = Manager.Exchanges.GetExchangeRate(baseAsset, quoteAsset, timeStamp);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Exchange rate not found for the pair", response.ErrorMessage);
            Assert.IsNull(response.ExchangeRate);
        }
    }
}