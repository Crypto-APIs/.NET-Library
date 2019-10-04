using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Exchanges.Rates
{
    [TestClass]
    public class ExchangeRate : BaseTest
    {
        [TestMethod]
        public void TestUsdBtc()
        {
            var response = Manager.Exchanges.Rates.ExchangeRate(BaseAsset, QuoteAsset);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.ExchangeRate);
            Assert.AreEqual(BaseAsset.Id, response.ExchangeRate.BaseAssetId);
        }

        [TestMethod]
        public void TestBtcUsd()
        {
            var response = Manager.Exchanges.Rates.ExchangeRate(QuoteAsset, BaseAsset);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.ExchangeRate);
            Assert.AreEqual(QuoteAsset.Id, response.ExchangeRate.BaseAssetId);
        }

        [TestMethod]
        public void TestUsdBtcTimeStamp()
        {
            var timeStamp = new DateTime(2019, 02, 03);
            var response = Manager.Exchanges.Rates.ExchangeRate(BaseAsset, QuoteAsset, timeStamp);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.ExchangeRate);
            Assert.AreEqual(BaseAsset.Id, response.ExchangeRate.BaseAssetId);
            Assert.AreEqual(timeStamp, response.ExchangeRate.Timestamp);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset of null was inappropriately allowed.")]
        public void TestNullBaseAsset()
        {
            Manager.Exchanges.Rates.ExchangeRate(baseAsset: null, quoteAsset: QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset of null was inappropriately allowed.")]
        public void TestNullQuoteAsset()
        {
            Manager.Exchanges.Rates.ExchangeRate(BaseAsset, quoteAsset: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset.Id of null was inappropriately allowed.")]
        public void TestNullBaseAssetId()
        {
            Manager.Exchanges.Rates.ExchangeRate(new Asset(), quoteAsset: QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset.Id of null was inappropriately allowed.")]
        public void TestNullQuoteAssetId()
        {
            Manager.Exchanges.Rates.ExchangeRate(BaseAsset, new Asset());
        }

        [TestMethod]
        public void TestIncorrectBaseAsset()
        {
            var baseAsset = new Asset("QWE'EWQ");
            var response = Manager.Exchanges.Rates.ExchangeRate(baseAsset, QuoteAsset);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Exchange rate not found for the pair", response.ErrorMessage);
            Assert.IsNull(response.ExchangeRate);
        }

        [TestMethod]
        public void TestIncorrectQuoteAsset()
        {
            var quoteAsset = new Asset("QWEE'WQ");
            var response = Manager.Exchanges.Rates.ExchangeRate(BaseAsset, quoteAsset);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Exchange rate not found for the pair", response.ErrorMessage);
            Assert.IsNull(response.ExchangeRate);
        }

        [TestMethod]
        public void TestIncorrectTimeStampFromPast()
        {
            var timeStamp = new DateTime(1960, 01, 01);
            var response = Manager.Exchanges.Rates.ExchangeRate(BaseAsset, QuoteAsset, timeStamp);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual("Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.", response.ErrorMessage);
                Assert.IsNull(response.ExchangeRate);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestIncorrectTimeStampFromFeature()
        {
            var timeStamp = new DateTime(DateTime.Now.Year + 1, 01, 01);
            var response = Manager.Exchanges.Rates.ExchangeRate(BaseAsset, QuoteAsset, timeStamp);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual("Exchange rate not found for the pair", response.ErrorMessage);
                Assert.IsNull(response.ExchangeRate);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        private Asset BaseAsset { get; } = new Asset("5b1ea92e584bf50020130612");
        private Asset QuoteAsset { get; } = new Asset("5b1ea92e584bf50020130615");
    }
}