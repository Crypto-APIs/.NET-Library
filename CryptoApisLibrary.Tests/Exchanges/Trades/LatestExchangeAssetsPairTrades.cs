using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Trades
{
    [TestClass]
    public class LatestExchangeAssetsPairTrades : BaseCollectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset of null was inappropriately allowed.")]
        public void NullAsset_Exception()
        {
            var exchange = Features.Bittrex;
            Asset baseAsset = null;
            var quoteAsset = Features.Usd;

            Manager.Exchanges.Trades.Latest(exchange, baseAsset, quoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset.Id of null was inappropriately allowed.")]
        public void NullAssetId_Exception()
        {
            var exchange = Features.Bittrex;
            var baseAsset = new Asset();
            var quoteAsset = Features.Usd;

            Manager.Exchanges.Trades.Latest(exchange, baseAsset, quoteAsset);
        }

        [TestMethod]
        public void UnexistingBaseAsset_ErrorMessage()
        {
            var exchange = Features.Bittrex;
            var baseAsset = Features.UnexistingAsset;
            var quoteAsset = Features.Usd;

            var response = Manager.Exchanges.Trades.Latest(exchange, baseAsset, quoteAsset);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset of null was inappropriately allowed.")]
        public void NullQuoteAsset_Exception()
        {
            var exchange = Features.Bittrex;
            var baseAsset = Features.Btc;
            Asset quoteAsset = null;

            Manager.Exchanges.Trades.Latest(exchange, baseAsset, quoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset.Id of null was inappropriately allowed.")]
        public void NullQuoteAssetId_Exception()
        {
            var exchange = Features.Bittrex;
            var baseAsset = Features.Btc;
            var quoteAsset = new Asset();

            Manager.Exchanges.Trades.Latest(exchange, baseAsset, quoteAsset);
        }

        [TestMethod]
        public void UnexistingQuoteAsset_ErrorMessage()
        {
            var exchange = Features.Bittrex;
            var baseAsset = Features.Btc;
            var quoteAsset = Features.UnexistingAsset;

            var response = Manager.Exchanges.Trades.Latest(exchange, baseAsset, quoteAsset);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void NullExchange_Exception()
        {
            Exchange exchange = null;
            var baseAsset = Features.Btc;
            var quoteAsset = Features.Usd;

            Manager.Exchanges.Trades.Latest(exchange, baseAsset, quoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void NullExchangeId_Exception()
        {
            var exchange = new Exchange();
            var baseAsset = Features.Btc;
            var quoteAsset = Features.Usd;

            Manager.Exchanges.Trades.Latest(exchange, baseAsset, quoteAsset);
        }

        [TestMethod]
        public void UnexistingExchange_ErrorMessage()
        {
            var exchange = Features.UnexistingExchange;
            var baseAsset = Features.Btc;
            var quoteAsset = Features.Usd;

            var response = Manager.Exchanges.Trades.Latest(exchange, baseAsset, quoteAsset);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Latest(Exchange, BaseAsset, QuoteAsset);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Latest(Exchange, BaseAsset, QuoteAsset, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Latest(Exchange, BaseAsset, QuoteAsset, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.Latest(Exchange, BaseAsset, QuoteAsset, skip, limit);
        }

        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Exchange Exchange { get; } = Features.Bittrex;
        private Asset BaseAsset { get; } = Features.Btc;
        private Asset QuoteAsset { get; } = Features.Usd;
    }
}