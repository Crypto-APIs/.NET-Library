using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.OrderBook
{
    [TestClass]
    public class OrderBook : BaseTest
    {
        [TestMethod]
        public void AllCorrect_ShouldPass()
        {
            var exchange = new Exchange { Name = "BITFINEX" };
            var baseAsset = new Asset { AssetId = "EOS" };
            var quoteAsset = new Asset { AssetId = "BTC" };

            var response = Manager.Exchanges.OrderBook.Get(exchange, baseAsset, quoteAsset);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.OrderBook, $"{nameof(response.OrderBook)} must not be null");
            Assert.IsNotNull(response.OrderBook.Depth, $"{nameof(response.OrderBook.Depth)} must not be null");
            AssertNotEmptyCollection("Asks", response.OrderBook.Depth.Asks);
            AssertNotEmptyCollection("Bids", response.OrderBook.Depth.Bids);
        }

        [TestMethod]
        public void SameAsset_ErrorMessage()
        {
            var exchange = new Exchange { Name = "BITFINEX" };
            var baseAsset = new Asset { AssetId = "EOS" };
            var quoteAsset = new Asset { AssetId = "EOS" };

            var response = Manager.Exchanges.OrderBook.Get(exchange, baseAsset, quoteAsset);

            AssertErrorMessage(response, "General Error: Record is not found");
            Assert.IsNull(response.OrderBook, $"{nameof(response.OrderBook)} must be null");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset of null was inappropriately allowed.")]
        public void NullBaseAsset_Exception()
        {
            var exchange = new Exchange { Name = "BITFINEX" };
            Asset baseAsset = null;
            var quoteAsset = new Asset { AssetId = "EOS" };

            Manager.Exchanges.OrderBook.Get(exchange, baseAsset, quoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset.Id of null was inappropriately allowed.")]
        public void NullBaseAssetId_Exception()
        {
            var exchange = new Exchange { Name = "BITFINEX" };
            var baseAsset = new Asset();
            var quoteAsset = new Asset { AssetId = "EOS" };

            Manager.Exchanges.OrderBook.Get(exchange, baseAsset, quoteAsset);
        }

        [TestMethod]
        public void UnexistingBaseAsset_ErrorMessage()
        {
            var exchange = new Exchange { Name = "BITFINEX" };
            var baseAsset = new Asset { AssetId = "QWE'EWQ" };
            var quoteAsset = new Asset { AssetId = "BTC" };

            var response = Manager.Exchanges.OrderBook.Get(exchange, baseAsset, quoteAsset);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "General Error: Record is not found");
                Assert.IsNull(response.OrderBook, $"{nameof(response.OrderBook)} must be null");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Quote of null was inappropriately allowed.")]
        public void NullQuoteAsset_Exception()
        {
            var exchange = new Exchange { Name = "BITFINEX" };
            var baseAsset = new Asset { AssetId = "EOS" };
            Asset quoteAsset = null;

            Manager.Exchanges.OrderBook.Get(exchange, baseAsset, quoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset.Id of null was inappropriately allowed.")]
        public void NullQuoteAssetId_Exception()
        {
            var exchange = new Exchange { Name = "BITFINEX" };
            var baseAsset = new Asset { AssetId = "EOS" };
            var quoteAsset = new Asset();

            Manager.Exchanges.OrderBook.Get(exchange, baseAsset, quoteAsset);
        }

        [TestMethod]
        public void UnexistingQuoteAsset_ErrorMessage()
        {
            var exchange = new Exchange { Name = "BITFINEX" };
            var baseAsset = new Asset { AssetId = "EOS" };
            var quoteAsset = new Asset { AssetId = "QWE'EWQ" };

            var response = Manager.Exchanges.OrderBook.Get(exchange, baseAsset, quoteAsset);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "General Error: Record is not found");
                Assert.IsNull(response.OrderBook, $"{nameof(response.OrderBook)} must be null");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void NullExchange_Exception()
        {
            Exchange exchange = null;
            var baseAsset = new Asset { AssetId = "EOS" };
            var quoteAsset = new Asset { AssetId = "BTC" };

            Manager.Exchanges.OrderBook.Get(exchange, baseAsset, quoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void NullExchangeId_Exception()
        {
            var exchange = new Exchange();
            var baseAsset = new Asset { AssetId = "EOS" };
            var quoteAsset = new Asset { AssetId = "BTC" };

            Manager.Exchanges.OrderBook.Get(exchange, baseAsset, quoteAsset);
        }

        [TestMethod]
        public void UnexistingExchange_ErrorMessage()
        {
            var exchange = new Exchange { Name = "QWE'EWQ" };
            var baseAsset = new Asset { AssetId = "EOS" };
            var quoteAsset = new Asset { AssetId = "BTC" };

            var response = Manager.Exchanges.OrderBook.Get(exchange, baseAsset, quoteAsset);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "General Error: Record is not found");
                Assert.IsNull(response.OrderBook, $"{nameof(response.OrderBook)} must be null");
            }
        }
    }
}