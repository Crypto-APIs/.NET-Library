using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.DataTypes.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class ExchangeRateInExchange : BaseTest
    {
        [TestMethod]
        public void TestUsdBtc()
        {
            var response = Manager.Exchanges.ExchangeRate(BaseAsset, QuoteAsset, Exchange);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Rate);
            Assert.AreEqual("5b1ea92e584bf50020130612", response.Rate.BaseAssetId);
        }

        [TestMethod]
        public void TestUsdBtcTimeStamp()
        {
            var timeStamp = new DateTime(2019, 02, 03);
            var response = Manager.Exchanges.ExchangeRate(BaseAsset, QuoteAsset, Exchange, timeStamp);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Rate);
        }

        [TestMethod]
        [ExpectedException(typeof(RequestException), "A BaseAsset of null was inappropriately allowed.")]
        public void TestUndefinedBaseAsset()
        {
            Manager.Exchanges.ExchangeRate(baseAsset: null, quoteAsset: QuoteAsset, exchange: Exchange);
        }

        [TestMethod]
        [ExpectedException(typeof(RequestException), "A QuoteAsset of null was inappropriately allowed.")]
        public void TestUndefinedQuoteAsset()
        {
            Manager.Exchanges.ExchangeRate(baseAsset: BaseAsset, quoteAsset: null, exchange: Exchange);
        }

        [TestMethod]
        public void TestIncorrectBaseAsset()
        {
            var baseAsset = new Asset("QWEEWQ");
            var response = Manager.Exchanges.ExchangeRate(baseAsset, QuoteAsset, Exchange);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Exchange rate not found for the pair", response.ErrorMessage);
            Assert.IsNull(response.Rate);
        }

        [TestMethod]
        public void TestIncorrectQuoteAsset()
        {
            var quoteAsset = new Asset("QWEEWQ");
            var response = Manager.Exchanges.ExchangeRate(BaseAsset, quoteAsset, Exchange);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Exchange rate not found for the pair", response.ErrorMessage);
            Assert.IsNull(response.Rate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void TestNullExchange()
        {
            Manager.Exchanges.ExchangeRate(BaseAsset, QuoteAsset, null);
        }

        [TestMethod]
        [ExpectedException(typeof(RequestException), "A Exchange.Id of null was inappropriately allowed.")]
        public void TestNullExchangeId()
        {
            Manager.Exchanges.ExchangeRates(BaseAsset, new Exchange());
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var response = Manager.Exchanges.ExchangeRate(BaseAsset, QuoteAsset, new Exchange("QWEEWQ"));

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Exchange rate not found for the pair", response.ErrorMessage);
            Assert.IsNull(response.Rate);
        }

        private Asset BaseAsset { get; } = new Asset("5b1ea92e584bf50020130612");
        private Asset QuoteAsset { get; } = new Asset("5b1ea92e584bf50020130615");
        private Exchange Exchange { get; } = new Exchange("5b4366dab98b280001540e16");
    }
}