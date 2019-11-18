using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Rates
{
    [TestClass]
    public class ExchangeRate : BaseTest
    {
        [TestMethod]
        public void BtcLtc_ShouldPass()
        {
            var baseAsset = Features.Btc;
            var quoteAsset = Features.Ltc;

            var response = Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must not be null");
            Assert.AreEqual(baseAsset.Id, response.ExchangeRate.BaseAssetId, true);
        }

        [TestMethod]
        public void LtcBtc_ShouldPass()
        {
            var baseAsset = Features.Ltc;
            var quoteAsset = Features.Btc;

            var response = Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must not be null");
            Assert.AreEqual(baseAsset.Id, response.ExchangeRate.BaseAssetId, true);
        }

        [TestMethod]
        public void UsdBtcUsingTimeStamp_ShouldPass()
        {
            var baseAsset = Features.Btc;
            var quoteAsset = Features.Ltc;
            var timeStamp = new DateTime(2019, 10, 03);

            var response = Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset, timeStamp);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must not be null");
            Assert.AreEqual(baseAsset.Id, response.ExchangeRate.BaseAssetId, true);
            Assert.AreEqual(timeStamp, response.ExchangeRate.Timestamp);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset of null was inappropriately allowed.")]
        public void NullBaseAsset_Exception()
        {
            Asset baseAsset = null;
            var quoteAsset = Features.Ltc;

            Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset.Id of null was inappropriately allowed.")]
        public void NullBaseAssetId_Exception()
        {
            var baseAsset = new Asset();
            var quoteAsset = Features.Ltc;

            Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset);
        }

        [TestMethod]
        public void UnexistingBaseAsset_ErrorMessage()
        {
            var baseAsset = Features.UnexistingAsset;
            var quoteAsset = Features.Ltc;

            var response = Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset);

            AssertErrorMessage(response, "Exchange rate not found for the pair");
            Assert.IsNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must be null");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset of null was inappropriately allowed.")]
        public void NullQuoteAsset_Exception()
        {
            var baseAsset = Features.Btc;
            Asset quoteAsset = null;

            Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset.Id of null was inappropriately allowed.")]
        public void NullQuoteAssetId_Exception()
        {
            var baseAsset = Features.Btc;
            var quoteAsset = new Asset();

            Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset);
        }

        [TestMethod]
        public void UnexistingQuoteAsset_ErrorMessage()
        {
            var baseAsset = Features.Btc;
            var quoteAsset = Features.UnexistingAsset;

            var response = Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset);

            AssertErrorMessage(response, "Exchange rate not found for the pair");
            Assert.IsNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must be null");
        }

        [TestMethod]
        public void IncorrectTimeStampFromPast_ErrorMessage()
        {
            var baseAsset = Features.Btc;
            var quoteAsset = Features.Ltc;
            var timeStamp = new DateTime(1960, 01, 01);

            var response = Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset, timeStamp);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.");
                Assert.IsNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must be null");
            }
        }

        [TestMethod]
        public void IncorrectTimeStampFromFeature_ErrorMessage()
        {
            var baseAsset = Features.Btc;
            var quoteAsset = Features.Ltc;
            var timeStamp = new DateTime(DateTime.Now.Year + 1, 01, 01);

            var response = Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset, timeStamp);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "Exchange rate not found for the pair");
                Assert.IsNull(response.ExchangeRate, $"{nameof(response.ExchangeRate)} must be null");
            }
        }
    }
}