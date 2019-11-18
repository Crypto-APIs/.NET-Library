using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.Exceptions;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Trades
{
    [TestClass]
    public class HistoricalTradesBySymbolStartDateEndDate : BaseCollectionTest
    {
        [TestMethod]
        public void IncorrectStartTimeFromPast_ErrorMessage()
        {
            var symbol = Features.BtcLtc;
            var startPeriod = new DateTime(1960, 01, 01);
            var endPeriod = new DateTime(1960, 02, 01);

            var response = Manager.Exchanges.Trades.Historical(symbol, startPeriod, endPeriod);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.");
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
        }

        [TestMethod]
        public void IncorrectEndTimeFromFeature_ErrorMessage()
        {
            var symbol = Features.BtcLtc;
            var startPeriod = new DateTime(2019, 09, 20);
            var endPeriod = new DateTime(DateTime.Now.Year + 1, 01, 01);

            var response = Manager.Exchanges.Trades.Historical(symbol, startPeriod, endPeriod);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertNullErrorMessage(response);
                AssertNotEmptyCollection(nameof(response.Trades), response.Trades);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(RequestException), "EndPeriod is less than StartPeriod.")]
        public void StartTimeMoreThanEndTime_Exception()
        {
            var symbol = Features.BtcLtc;
            var startPeriod = new DateTime(DateTime.Now.Year, 01, 01);
            var endPeriod = new DateTime(DateTime.Now.Year - 1, 01, 01);

            Manager.Exchanges.Trades.Historical(symbol, startPeriod, endPeriod);
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Historical(Symbol, StartPeriod, EndPeriod);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Historical(Symbol, StartPeriod, EndPeriod, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Historical(Symbol, StartPeriod, EndPeriod, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.Historical(Symbol, StartPeriod, EndPeriod, skip, limit);
        }

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;

        private Symbol Symbol { get; } = Features.BtcLtc;
        private DateTime StartPeriod { get; } = new DateTime(2019, 09, 20);
        private DateTime EndPeriod { get; } = new DateTime(2019, 09, 25);
    }
}