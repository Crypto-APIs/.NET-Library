using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Trades
{
    [TestClass]
    public class HistoricalTradesByAssetPair : BaseCollectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset of null was inappropriately allowed.")]
        public void NullBaseAsset_Exception()
        {
            Asset baseAsset = null;
            var quoteAsset = Features.Usd;

            Manager.Exchanges.Trades.Historical(baseAsset, quoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset.Id of null was inappropriately allowed.")]
        public void NullBaseAssetId_Exception()
        {
            var baseAsset = new Asset();
            var quoteAsset = Features.Usd;

            Manager.Exchanges.Trades.Historical(baseAsset, quoteAsset);
        }

        [TestMethod]
        public void UnexistingBaseAsset_ErrorMessage()
        {
            var baseAsset = Features.UnexistingAsset;
            var quoteAsset = Features.Usd;

            var response = Manager.Exchanges.Trades.Historical(baseAsset, quoteAsset);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "General validation error: Wrong ID format for baseAsset");
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Quote of null was inappropriately allowed.")]
        public void NullQuoteAsset_Exception()
        {
            var baseAsset = Features.Btc;
            Asset quoteAsset = null;

            Manager.Exchanges.Trades.Historical(baseAsset, quoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset.Id of null was inappropriately allowed.")]
        public void NullQuoteAssetId_Exception()
        {
            var baseAsset = Features.Btc;
            var quoteAsset = new Asset();

            Manager.Exchanges.Trades.Historical(baseAsset, quoteAsset);
        }

        [TestMethod]
        public void UnexistingQuoteAsset_ErrorMessage()
        {
            var baseAsset = Features.Btc;
            var quoteAsset = Features.UnexistingAsset;

            var response = Manager.Exchanges.Trades.Historical(baseAsset, quoteAsset);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "General validation error: Wrong ID format for quoteAsset");
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
        }

        [Ignore] //todo: random sequence of collection elements with equality "EventTime"
        [TestMethod]
        public override void MainTest()
        { }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Historical(BaseAsset, QuoteAsset);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Historical(BaseAsset, QuoteAsset, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Historical(BaseAsset, QuoteAsset, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.Historical(BaseAsset, QuoteAsset, skip, limit);
        }

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;
        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Asset BaseAsset { get; } = Features.Btc;
        private Asset QuoteAsset { get; } = Features.Usd;
        //protected override string SortingField { get; } = nameof(Trade.EventTime);
    }
}