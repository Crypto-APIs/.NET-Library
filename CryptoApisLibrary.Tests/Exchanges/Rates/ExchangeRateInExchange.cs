using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Rates
{
    [TestClass]
    public class ExchangeRateInExchange : BaseTest
    {
        [TestMethod]
        public void BtcLtc_ShouldPass()
        {
            var baseAsset = Features.Btc;
            var quoteAsset = Features.Ltc;
            var exchange = Features.Bittrex;

            var response = Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset, exchange);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Rate, $"{nameof(response.Rate)} must not be null");
            Assert.AreEqual(baseAsset.Id, response.Rate.BaseAssetId, true);
        }

        [TestMethod]
        public void LtcBtc_ShouldPass()
        {
            var baseAsset = Features.Ltc;
            var quoteAsset = Features.Btc;
            var exchange = Features.Bittrex;

            var response = Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset, exchange);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Rate, $"{nameof(response.Rate)} must not be null");
            Assert.AreEqual(baseAsset.Id, response.Rate.BaseAssetId, true);
        }

        [TestMethod]
        public void BtcLtcUsingTimeStamp_ShouldPass()
        {
            var baseAsset = Features.Btc;
            var quoteAsset = Features.Ltc;
            var exchange = Features.Bittrex;
            var timeStamp = new DateTime(2019, 09, 23);

            var response = Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset, exchange, timeStamp);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Rate);
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
            var exchange = Features.Bittrex;

            var response = Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset, exchange);

            AssertErrorMessage(response, "Exchange rate not found for the pair");
            Assert.IsNull(response.Rate);
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
            var exchange = Features.Bittrex;

            var response = Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset, exchange);

            AssertErrorMessage(response, "Exchange rate not found for the pair");
            Assert.IsNull(response.Rate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Exchange of null was inappropriately allowed.")]
        public void NullExchange_Exception()
        {
            var baseAsset = Features.Btc;
            var quoteAsset = Features.Ltc;
            Exchange exchange = null;

            Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset, exchange);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Exchange.Id of null was inappropriately allowed.")]
        public void NullExchangeId_Exception()
        {
            var baseAsset = Features.Btc;
            var exchange = new Exchange();

            Manager.Exchanges.Rates.GetAny(baseAsset, exchange);
        }

        [TestMethod]
        public void UnexistingExchange_ErrorMessage()
        {
            var baseAsset = Features.Btc;
            var quoteAsset = Features.Ltc;
            var exchange = Features.UnexistingExchange;

            var response = Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset, exchange);

            AssertErrorMessage(response, "Exchange rate not found for the pair");
            Assert.IsNull(response.Rate);
        }

        [TestMethod]
        public void IncorrectTimeStampFromPast_ErrorMessage()
        {
            var baseAsset = Features.Btc;
            var quoteAsset = Features.Ltc;
            var exchange = Features.Bittrex;
            var timeStamp = new DateTime(1960, 01, 01);

            var response = Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset, exchange, timeStamp);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.");
                Assert.IsNull(response.Rate);
            }
        }

        [TestMethod]
        public void IncorrectTimeStampFromFeature_ErrorMessage()
        {
            var baseAsset = Features.Btc;
            var quoteAsset = Features.Ltc;
            var exchange = Features.Bittrex;
            var timeStamp = new DateTime(DateTime.Now.Year + 1, 01, 01);

            var response = Manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset, exchange, timeStamp);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "Exchange rate not found for the pair");
                Assert.IsNull(response.Rate);
            }
        }
    }
}