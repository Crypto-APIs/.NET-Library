using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Trades
{
    [TestClass]
    public class HistoricalTradesByAssetPairAndExchangeStartDate : BaseCollectionTest
    {
        [TestMethod]
        public void IncorrectStartTimeFromPast_ErrorMessage()
        {
            var exchange = Features.Bittrex;
            var baseAsset = Features.Btc;
            var quoteAsset = Features.Usd;
            var startPeriod = new DateTime(1960, 01, 01);

            var response = Manager.Exchanges.Trades.Historical(exchange, baseAsset, quoteAsset, startPeriod);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.");
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
        }

        [TestMethod]
        public void IncorrectStartTimeFromFeature_ErrorMessage()
        {
            var exchange = Features.Bittrex;
            var baseAsset = Features.Btc;
            var quoteAsset = Features.Usd;
            var startPeriod = new DateTime(DateTime.Now.Year + 1, 01, 01);

            var response = Manager.Exchanges.Trades.Historical(exchange, baseAsset, quoteAsset, startPeriod);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertNullErrorMessage(response);
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, QuoteAsset, StartPeriod);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, QuoteAsset, StartPeriod, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, QuoteAsset, StartPeriod, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, QuoteAsset, StartPeriod, skip, limit);
        }

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;
        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Exchange Exchange { get; } = Features.Bittrex;
        private Asset BaseAsset { get; } = Features.Btc;
        private Asset QuoteAsset { get; } = Features.Usd;
        private DateTime StartPeriod { get; } = new DateTime(2019, 09, 23);
    }
}