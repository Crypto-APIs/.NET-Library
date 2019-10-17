using System;
using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Exchanges.Rates
{
    [TestClass]
    public class ExchangeRateInExchange : BaseTest
    {
        [TestMethod]
        public void TestBtcLtc()
        {
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, Exchange);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Rate, $"{nameof(response.Rate)} must not be null");
            Assert.AreEqual(BaseAsset.Id, response.Rate.BaseAssetId, true);
        }

        [TestMethod]
        public void TestBtcLtcTimeStamp()
        {
            var timeStamp = new DateTime(2019, 09, 23);
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, Exchange, timeStamp);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Rate);
        }

        [TestMethod]
        public void TestIncorrectTimeStampFromPast()
        {
            var timeStamp = new DateTime(1960, 01, 01);
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, Exchange, timeStamp);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.");
                Assert.IsNull(response.Rate);
            }
        }

        [TestMethod]
        public void TestIncorrectTimeStampFromFeature()
        {
            var timeStamp = new DateTime(DateTime.Now.Year + 1, 01, 01);
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, Exchange, timeStamp);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "Exchange rate not found for the pair");
                Assert.IsNull(response.Rate);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset of null was inappropriately allowed.")]
        public void TestNullBaseAsset()
        {
            Asset baseAsset = null;
            Manager.Exchanges.Rates.GetOne(baseAsset, QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset of null was inappropriately allowed.")]
        public void TestNullQuoteAsset()
        {
            Asset quoteAsset = null;
            Manager.Exchanges.Rates.GetOne(BaseAsset, quoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset.Id of null was inappropriately allowed.")]
        public void TestNullBaseAssetId()
        {
            var baseAsset = new Asset();
            Manager.Exchanges.Rates.GetOne(baseAsset, QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset.Id of null was inappropriately allowed.")]
        public void TestNullQuoteAssetId()
        {
            var quoteAsset = new Asset();
            Manager.Exchanges.Rates.GetOne(BaseAsset, quoteAsset);
        }

        [TestMethod]
        public void TestIncorrectBaseAsset()
        {
            var baseAsset = Features.UnexistingAsset;
            var response = Manager.Exchanges.Rates.GetOne(baseAsset, QuoteAsset, Exchange);

            AssertErrorMessage(response, "Exchange rate not found for the pair");
            Assert.IsNull(response.Rate);
        }

        [TestMethod]
        public void TestIncorrectQuoteAsset()
        {
            var quoteAsset = Features.UnexistingAsset;
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, quoteAsset, Exchange);

            AssertErrorMessage(response, "Exchange rate not found for the pair");
            Assert.IsNull(response.Rate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Exchange of null was inappropriately allowed.")]
        public void TestNullExchange()
        {
            Exchange exchange = null;
            Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, exchange);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Exchange.Id of null was inappropriately allowed.")]
        public void TestNullExchangeId()
        {
            var exchange = new Exchange();
            Manager.Exchanges.Rates.GetAny(BaseAsset, exchange);
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, Features.UnexistingExchange);

            AssertErrorMessage(response, "Exchange rate not found for the pair");
            Assert.IsNull(response.Rate);
        }

        private Asset BaseAsset { get; } = Features.Btc;
        private Asset QuoteAsset { get; } = Features.Ltc;
        private Exchange Exchange { get; } = Features.Bittrex;
    }
}