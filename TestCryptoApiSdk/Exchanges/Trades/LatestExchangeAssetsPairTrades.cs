using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Exchanges.Trades
{
    [Ignore] // todo: check IsPerhapsNotAnExactMatch flag
    [TestClass]
    public class LatestExchangeAssetsPairTrades : BaseCollectionTest
    {
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset of null was inappropriately allowed.")]
        public void TestNullAsset()
        {
            Asset baseAsset = null;
            Manager.Exchanges.Trades.Latest(Exchange, baseAsset, QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset.Id of null was inappropriately allowed.")]
        public void TestNullAssetId()
        {
            var baseAsset = new Asset();
            Manager.Exchanges.Trades.Latest(Exchange, baseAsset, QuoteAsset);
        }

        [TestMethod]
        public void TestIncorrectBaseAsset()
        {
            var baseAsset = Features.UnexistingAsset;
            var response = Manager.Exchanges.Trades.Latest(Exchange, baseAsset, QuoteAsset);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset of null was inappropriately allowed.")]
        public void TestNullQuoteAsset()
        {
            Asset quoteAsset = null;
            Manager.Exchanges.Trades.Latest(Exchange, BaseAsset, quoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset.Id of null was inappropriately allowed.")]
        public void TestNullQuoteAssetId()
        {
            var quoteAsset = new Asset();
            Manager.Exchanges.Trades.Latest(Exchange, BaseAsset, quoteAsset);
        }

        [TestMethod]
        public void TestIncorrectQuoteAsset()
        {
            var quoteAsset = Features.UnexistingAsset;
            var response = Manager.Exchanges.Trades.Latest(Exchange, BaseAsset, quoteAsset);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void TestNullExchange()
        {
            Exchange exchange = null;
            Manager.Exchanges.Trades.Latest(exchange, BaseAsset, QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void TestNullExchangeId()
        {
            var exchange = new Exchange();
            Manager.Exchanges.Trades.Latest(exchange, BaseAsset, QuoteAsset);
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var exchange = Features.UnexistingExchange;
            var response = Manager.Exchanges.Trades.Latest(exchange, BaseAsset, QuoteAsset);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        private Exchange Exchange { get; } = Features.Bittrex;
        private Asset BaseAsset { get; } = Features.Btc;
        private Asset QuoteAsset { get; } = Features.Ltc;
    }
}