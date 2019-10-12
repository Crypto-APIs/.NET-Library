using System;
using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.ExchangesBugs.Rates
{
    [TestClass]
    public class ExchangeRateInExchange : BaseTest
    {
        [TestMethod]
        public void TestUsdBtc()
        {
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, Exchange);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Rate, $"{nameof(response.Rate)} must not be null");
            Assert.AreEqual("5b1ea92e584bf50020130612", response.Rate.BaseAssetId);
        }

        [TestMethod]
        public void TestUsdBtcTimeStamp()
        {
            var timeStamp = new DateTime(2019, 02, 03);
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, Exchange, timeStamp);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Rate);
        }

        [TestMethod]
        public void TestIncorrectTimeStampFromPast()
        {
            var timeStamp = new DateTime(1960, 01, 01);
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, Exchange, timeStamp);

            if (IsAdditionalPackagePlan)
            {
                AssertErrorMessage(response, "Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.");
                Assert.IsNull(response.Rate);
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
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, Exchange, timeStamp);

            if (IsAdditionalPackagePlan)
            {
                AssertNullErrorMessage(response);
                Assert.IsNull(response.Rate);
            }
            else
            {
                AssertErrorMessage(response, "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
            }
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
            var response = Manager.Exchanges.Rates.GetOne(baseAsset, QuoteAsset, Exchange);

            AssertErrorMessage(response, "Exchange rate not found for the pair");
            Assert.IsNull(response.Rate);
        }

        [TestMethod]
        public void TestIncorrectQuoteAsset()
        {
            var quoteAsset = new Asset("QWE'EWQ");
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, quoteAsset, Exchange);

            AssertErrorMessage(response, "Exchange rate not found for the pair");
            Assert.IsNull(response.Rate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Exchange of null was inappropriately allowed.")]
        public void TestNullExchange()
        {
            Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Exchange.Id of null was inappropriately allowed.")]
        public void TestNullExchangeId()
        {
            Manager.Exchanges.Rates.GetAny(BaseAsset, new Exchange());
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var response = Manager.Exchanges.Rates.GetOne(BaseAsset, QuoteAsset, new Exchange("QWE'EWQ"));

            AssertErrorMessage(response, "Exchange rate not found for the pair");
            Assert.IsNull(response.Rate);
        }

        private Asset BaseAsset { get; } = new Asset("5b1ea92e584bf50020130612");
        private Asset QuoteAsset { get; } = new Asset("5b1ea92e584bf50020130615");
        private Exchange Exchange { get; } = new Exchange("5b4366dab98b280001540e16");
    }
}