using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Exchanges.Rates
{
    [TestClass]
    public class ExchangeRate : BaseTest
    {
        [TestMethod]
        public void TestUsdBtc()
        {
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must not be null");
            Assert.AreEqual(BaseAsset.Id, response.ExchangeRate.BaseAssetId);
        }

        [TestMethod]
        public void TestBtcUsd()
        {
            var response = Manager.Exchanges.Rates.GetOne(QuoteAsset, BaseAsset);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must not be null");
            Assert.AreEqual(QuoteAsset.Id, response.ExchangeRate.BaseAssetId);
        }

        [TestMethod]
        public void TestUsdBtcTimeStamp()
        {
            var timeStamp = new DateTime(2019, 02, 03);
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, timeStamp);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must not be null");
            Assert.AreEqual(BaseAsset.Id, response.ExchangeRate.BaseAssetId);
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
            Manager.Exchanges.Rates.GetOne(new Asset(), quoteAsset: QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset.Id of null was inappropriately allowed.")]
        public void TestNullQuoteAssetId()
        {
            Manager.Exchanges.Rates.GetOne(BaseAsset, new Asset());
        }

        [TestMethod]
        public void TestIncorrectBaseAsset()
        {
            var baseAsset = new Asset("QWE'EWQ");
            var response = Manager.Exchanges.Rates.GetOne(baseAsset, QuoteAsset);

            AssertErrorMessage(response, "Exchange rate not found for the pair");
            Assert.IsNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must be null");
        }

        [TestMethod]
        public void TestIncorrectQuoteAsset()
        {
            var quoteAsset = new Asset("QWEE'WQ");
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, quoteAsset);

            AssertErrorMessage(response, "Exchange rate not found for the pair");
            Assert.IsNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must be null");
        }

        [TestMethod]
        public void TestIncorrectTimeStampFromPast()
        {
            var timeStamp = new DateTime(1960, 01, 01);
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, timeStamp);

            if (IsAdditionalPackagePlan)
            {
                AssertErrorMessage(response, "Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.");
                Assert.IsNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must be null");
            }
            else
            {
                AssertErrorMessage(response, "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
            }
        }

        [TestMethod]
        public void TestIncorrectTimeStampFromFeature()
        {
            var timeStamp = new DateTime(DateTime.Now.Year + 1, 01, 01);
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, timeStamp);

            if (IsAdditionalPackagePlan)
            {
                AssertErrorMessage(response, "Exchange rate not found for the pair");
                Assert.IsNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must be null");
            }
            else
            {
                AssertErrorMessage(response, "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
            }
        }

        private Asset BaseAsset { get; } = new Asset("5b1ea92e584bf50020130612");
        private Asset QuoteAsset { get; } = new Asset("5b1ea92e584bf50020130615");
    }
}