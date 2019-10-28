using System;
using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Exchanges.Rates
{
    [TestClass]
    public class ExchangeRate : BaseTest
    {
        [TestMethod]
        public void TestBtcLtc()
        {
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must not be null");
            Assert.AreEqual(BaseAsset.Id, response.ExchangeRate.BaseAssetId, true);
        }

        [TestMethod]
        public void TestLtcBtc()
        {
            var baseAsset = QuoteAsset;
            var quoteAsset = BaseAsset;
            var response = Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must not be null");
            Assert.AreEqual(QuoteAsset.Id, response.ExchangeRate.BaseAssetId, true);
        }

        [TestMethod]
        public void TestUsdBtcTimeStamp()
        {
            var timeStamp = new DateTime(2019, 10, 03);
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, timeStamp);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must not be null");
            Assert.AreEqual(BaseAsset.Id, response.ExchangeRate.BaseAssetId, true);
            Assert.AreEqual(timeStamp, response.ExchangeRate.Timestamp);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset of null was inappropriately allowed.")]
        public void TestNullBaseAsset()
        {
            Manager.Exchanges.Rates.GetOne(baseAsset: null, quoteAsset: QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset of null was inappropriately allowed.")]
        public void TestNullQuoteAsset()
        {
            Manager.Exchanges.Rates.GetOne(BaseAsset, quoteAsset: null);
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
            var response = Manager.Exchanges.Rates.GetOne(baseAsset, QuoteAsset);

            AssertErrorMessage(response, "Exchange rate not found for the pair");
            Assert.IsNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must be null");
        }

        [TestMethod]
        public void TestIncorrectQuoteAsset()
        {
            var quoteAsset = Features.UnexistingAsset;
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, quoteAsset);

            AssertErrorMessage(response, "Exchange rate not found for the pair");
            Assert.IsNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must be null");
        }

        [TestMethod]
        public void TestIncorrectTimeStampFromPast()
        {
            var timeStamp = new DateTime(1960, 01, 01);
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, timeStamp);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.");
                Assert.IsNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must be null");
            }
        }

        [TestMethod]
        public void TestIncorrectTimeStampFromFeature()
        {
            var timeStamp = new DateTime(DateTime.Now.Year + 1, 01, 01);
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, timeStamp);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "Exchange rate not found for the pair");
                Assert.IsNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must be null");
            }
        }

        private Asset BaseAsset { get; } = Features.Btc;
        private Asset QuoteAsset { get; } = Features.Ltc;
    }
}