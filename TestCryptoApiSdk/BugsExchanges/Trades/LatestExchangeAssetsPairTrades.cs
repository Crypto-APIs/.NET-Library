using System;
using System.Diagnostics;
using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.BugsExchanges.Trades
{
    [TestClass]
    public class LatestExchangeAssetsPairTrades : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Latest(Exchange, BaseAsset, QuoteAsset);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Latest(Exchange, BaseAsset, QuoteAsset, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Latest(Exchange, BaseAsset, QuoteAsset, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            Debug.Assert(Skip.HasValue);
            Debug.Assert(Limit.HasValue);
            return Manager.Exchanges.Trades.Latest(Exchange, BaseAsset, QuoteAsset, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset of null was inappropriately allowed.")]
        public void TestNullAsset()
        {
            Manager.Exchanges.Trades.Latest(exchange: Exchange, baseAsset: null, quoteAsset: QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset.Id of null was inappropriately allowed.")]
        public void TestNullAssetId()
        {
            Manager.Exchanges.Trades.Latest(Exchange, new Asset(), QuoteAsset);
        }

        [TestMethod]
        public void TestIncorrectBaseAsset()
        {
            var baseAsset = new Asset("QWE'EWQ1");
            var response = Manager.Exchanges.Trades.Latest(Exchange, baseAsset, QuoteAsset);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset of null was inappropriately allowed.")]
        public void TestNullQuoteAsset()
        {
            Manager.Exchanges.Trades.Latest(Exchange, BaseAsset, quoteAsset: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset.Id of null was inappropriately allowed.")]
        public void TestNullQuoteAssetId()
        {
            Manager.Exchanges.Trades.Latest(Exchange, BaseAsset, new Asset());
        }

        [TestMethod]
        public void TestIncorrectQuoteAsset()
        {
            var quoteAsset = new Asset("QWE'EWQ1");
            var response = Manager.Exchanges.Trades.Latest(Exchange, BaseAsset, quoteAsset);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void TestNullExchange()
        {
            Manager.Exchanges.Trades.Latest(exchange: null, baseAsset: BaseAsset, quoteAsset: QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void TestNullExchangeId()
        {
            Manager.Exchanges.Trades.Latest(new Exchange(), BaseAsset, QuoteAsset);
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var exchange = new Exchange("QWE'EWQ1");
            var response = Manager.Exchanges.Trades.Latest(exchange, BaseAsset, QuoteAsset);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        private Exchange Exchange { get; } = new Exchange("5b1ea9d21090c200146f7362");
        private Asset BaseAsset { get; } = new Asset("5b1ea92e584bf50020130612");
        private Asset QuoteAsset { get; } = new Asset("5b1ea92e584bf50020130615");
    }
}