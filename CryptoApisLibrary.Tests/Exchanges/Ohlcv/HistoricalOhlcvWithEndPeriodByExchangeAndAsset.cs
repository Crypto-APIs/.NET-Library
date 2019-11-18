using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.Exceptions;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Ohlcv
{
    [TestClass]
    public class HistoricalOhlcvWithEndPeriodByExchangeAndAsset : BaseCollectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(RequestException), "EndPeriod is less than StartPeriod.")]
        public void StartTimeMoreThanEndTime_Exception()
        {
            var exchange = Features.Bittrex;
            var asset = Features.Btc;
            var period = new Period("1day");
            var startPeriod = new DateTime(DateTime.Now.Year, 01, 01);
            var endPeriod = new DateTime(DateTime.Now.Year - 1, 01, 01);

            Manager.Exchanges.Ohlcv.Historical(exchange, asset, period, startPeriod, endPeriod);
        }

        [TestMethod]
        public void IncorrectEndTimeFromFeature_EmptyResultCollection()
        {
            var exchange = Features.Bittrex;
            var asset = Features.Btc;
            var period = new Period("1day");
            var startPeriod = new DateTime(2019, 04, 15);
            var endPeriod = new DateTime(DateTime.Now.Year + 1, 01, 01);

            var response = Manager.Exchanges.Ohlcv.Historical(exchange, asset, period, startPeriod, endPeriod);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertNullErrorMessage(response);
                Assert.IsNotNull(response.Ohlcv, $"{nameof(response.Ohlcv)} must not be null");
                AssertNotEmptyCollection(nameof(response.Ohlcv), response.Ohlcv);
            }
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Ohlcv.Historical(Exchange, Asset, Period, StartPeriod, EndPeriod);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Ohlcv.Historical(Exchange, Asset, Period, StartPeriod, EndPeriod, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Ohlcv.Historical(Exchange, Asset, Period, StartPeriod, EndPeriod, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Ohlcv.Historical(Exchange, Asset, Period, StartPeriod, EndPeriod, skip, limit);
        }

        private Exchange Exchange { get; } = Features.Bittrex;
        private Asset Asset { get; } = Features.Btc;
        private Period Period { get; } = new Period("1day");
        private DateTime StartPeriod { get; } = new DateTime(2019, 04, 15);
        private DateTime EndPeriod { get; } = new DateTime(2019, 10, 01);
    }
}