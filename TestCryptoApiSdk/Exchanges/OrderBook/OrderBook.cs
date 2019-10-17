using System;
using System.Linq;
using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Exchanges.OrderBook
{
    [TestClass]
    public class OrderBook : BaseTest
    {
        [TestMethod]
        public void TestSimple()
        {
            var response = Manager.Exchanges.OrderBook.Get(Exchange, BaseAsset, QuoteAsset);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.OrderBook, $"{nameof(response.OrderBook)} must not be null");
            Assert.IsNotNull(response.OrderBook.Depth, $"{nameof(response.OrderBook.Depth)} must not be null");
            Assert.IsTrue(response.OrderBook.Depth.Asks.Any() || response.OrderBook.Depth.Bids.Any(), "Collection must not be empty");
        }

        [TestMethod]
        public void TestSameAsset()
        {
            var response = Manager.Exchanges.OrderBook.Get(Exchange, BaseAsset, BaseAsset);

            AssertErrorMessage(response, "General Error: Record is not found");
            Assert.IsNull(response.OrderBook, $"{nameof(response.OrderBook)} must be null");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset of null was inappropriately allowed.")]
        public void TestNullBaseAsset()
        {
            Asset baseAsset = null;
            Manager.Exchanges.OrderBook.Get(Exchange, baseAsset, QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Quote of null was inappropriately allowed.")]
        public void TestNullQuoteAsset()
        {
            Asset quoteAsset = null;
            Manager.Exchanges.OrderBook.Get(Exchange, BaseAsset, quoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void TestNullExchange()
        {
            Exchange exchange = null;
            Manager.Exchanges.OrderBook.Get(exchange, BaseAsset, QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset.Id of null was inappropriately allowed.")]
        public void TestNullBaseAssetId()
        {
            var baseAsset = new Asset();
            Manager.Exchanges.OrderBook.Get(Exchange, baseAsset, QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset.Id of null was inappropriately allowed.")]
        public void TestNullQuoteAssetId()
        {
            var quoteAsset = new Asset();
            Manager.Exchanges.OrderBook.Get(Exchange, BaseAsset, quoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void TestNullExchangeId()
        {
            var exchange = new Exchange();
            Manager.Exchanges.OrderBook.Get(exchange, BaseAsset, QuoteAsset);
        }

        [TestMethod]
        public void TestIncorrectBaseAsset()
        {
            var baseAsset = new Asset {AssetId = "qw'e"};
            var response = Manager.Exchanges.OrderBook.Get(Exchange, baseAsset, QuoteAsset);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "General Error: Record is not found");
                Assert.IsNull(response.OrderBook, $"{nameof(response.OrderBook)} must be null");
            }
        }

        [TestMethod]
        public void TestIncorrectQuoteAsset()
        {
            var quoteAsset = new Asset { AssetId = "qw'e" };
            var response = Manager.Exchanges.OrderBook.Get(Exchange, BaseAsset, quoteAsset);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "General Error: Record is not found");
                Assert.IsNull(response.OrderBook, $"{nameof(response.OrderBook)} must be null");
            }
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var exchange = new Exchange { ExchangeId = "qw'e" };
            var response = Manager.Exchanges.OrderBook.Get(exchange, BaseAsset, QuoteAsset);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "General Error: Record is not found");
                Assert.IsNull(response.OrderBook, $"{nameof(response.OrderBook)} must be null");
            }
        }

        private Exchange Exchange { get; } = new Exchange { ExchangeId = "BITFINEX" };
        private Asset BaseAsset { get; } = new Asset { AssetId = "EOS" };
        private Asset QuoteAsset { get; } = new Asset { AssetId = "BTC" };
    }
}