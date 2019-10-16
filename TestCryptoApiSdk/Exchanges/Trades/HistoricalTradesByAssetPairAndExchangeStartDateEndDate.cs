using System;
using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.DataTypes.Exceptions;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Exchanges.Trades
{
    [Ignore] // todo: note #8
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
                AssertNullErrorMessage(response);
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

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;
        //protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Exchange Exchange { get; } = Features.Bittrex;
        private Asset BaseAsset { get; } = Features.Bch;
        private Asset QuoteAsset { get; } = Features.Ltc;
        private DateTime StartPeriod { get; } = new DateTime(2019, 06, 01);
        private DateTime EndPeriod { get; } = new DateTime(2019, 06, 10);
    }
}