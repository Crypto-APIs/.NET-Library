using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.Exceptions;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Exchanges.Trades
{
    [TestClass]
    public class HistoricalTradesByAssetPairAndExchangeStartDateEndDate : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, QuoteAsset, StartPeriod, EndPeriod);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, QuoteAsset, StartPeriod, EndPeriod, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, QuoteAsset, StartPeriod, EndPeriod, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, QuoteAsset, StartPeriod, EndPeriod, skip, limit);
        }

        [TestMethod]
        public void TestIncorrectStartTimeFromPast()
        {
            var startPeriod = new DateTime(1960, 01, 01);
            var endPeriod = new DateTime(1960, 02, 01);
            var response = Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, QuoteAsset, startPeriod, endPeriod);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, 
                    "Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.");
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
        }

        [TestMethod]
        public void TestIncorrectEndTimeFromFeature()
        {
            var endPeriod = new DateTime(DateTime.Now.Year + 1, 01, 01);
            var response = Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, QuoteAsset, StartPeriod, endPeriod);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "Exceeded limit of 1 day period for historical data");
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(RequestException), "EndPeriod is less than StartPeriod.")]
        public void TestIncorrectTimeInterval()
        {
            var startPeriod = new DateTime(DateTime.Now.Year, 01, 01);
            var endPeriod = new DateTime(DateTime.Now.Year - 1, 01, 01);
            Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, QuoteAsset, startPeriod, endPeriod);
        }

        [TestMethod]
        public void TestTooBigTimeInterval()
        {
            var startPeriod = new DateTime(2019, 09, 20);
            var endPeriod = new DateTime(2019, 09, 25);
            var response = Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, QuoteAsset, startPeriod, endPeriod);
            AssertErrorMessage(response, "Exceeded limit of 1 day period for historical data");
        }

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;
        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Exchange Exchange { get; } = Features.Bittrex;
        private Asset BaseAsset { get; } = Features.Btc;
        private Asset QuoteAsset { get; } = Features.Usd;
        private DateTime StartPeriod { get; } = new DateTime(2019, 09, 20);
        private DateTime EndPeriod { get; } = new DateTime(2019, 09, 21);
    }
}