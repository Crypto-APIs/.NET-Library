using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Trades
{
    [TestClass]
    public class LatestAssetsPairTrades : BaseCollectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset of null was inappropriately allowed.")]
        public void NullAsset_Exception()
        {
            Asset baseAsset = null;
            var quoteAsset = Features.Usd;

            Manager.Exchanges.Trades.Latest(baseAsset, quoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset.Id of null was inappropriately allowed.")]
        public void NullAssetId_Exception()
        {
            var baseAsset = new Asset();
            var quoteAsset = Features.Usd;

            Manager.Exchanges.Trades.Latest(baseAsset, quoteAsset);
        }

        [TestMethod]
        public void UnexistingBaseAsset_ErrorMessage()
        {
            var baseAsset = Features.UnexistingAsset;
            var quoteAsset = Features.Usd;

            var response = Manager.Exchanges.Trades.Latest(baseAsset, quoteAsset);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset of null was inappropriately allowed.")]
        public void NullQuoteAsset_Exception()
        {
            var baseAsset = Features.Btc;
            Asset quoteAsset = null;

            Manager.Exchanges.Trades.Latest(baseAsset, quoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset.Id of null was inappropriately allowed.")]
        public void NullQuoteAssetId_Exception()
        {
            var baseAsset = Features.Btc;
            var quoteAsset = new Asset();

            Manager.Exchanges.Trades.Latest(baseAsset, quoteAsset);
        }

        [TestMethod]
        public void UnexistingQuoteAsset_ErrorMessage()
        {
            var baseAsset = Features.Btc;
            var quoteAsset = Features.UnexistingAsset;

            var response = Manager.Exchanges.Trades.Latest(baseAsset, quoteAsset);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Latest(BaseAsset, QuoteAsset);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Latest(BaseAsset, QuoteAsset, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Latest(BaseAsset, QuoteAsset, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.Latest(BaseAsset, QuoteAsset, skip, limit);
        }

        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Asset BaseAsset { get; } = Features.Btc;
        private Asset QuoteAsset { get; } = Features.Usd;
    }
}