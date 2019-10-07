using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.DataTypes.Exceptions;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdk.Exchanges.Trades
{
    [TestClass]
    public class HistoricalTradesBySymbolStartDateEndDate : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Historical(Symbol, StartPeriod, EndPeriod);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Historical(Symbol, StartPeriod, EndPeriod, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Historical(Symbol, StartPeriod, EndPeriod, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.Historical(Symbol, StartPeriod, EndPeriod, skip, limit);
        }

        [TestMethod]
        public void TestIncorrectStartTimeFromPast()
        {
            var startPeriod = new DateTime(1960, 01, 01);
            var endPeriod = new DateTime(1960, 02, 01);
            var response = Manager.Exchanges.Trades.Historical(Symbol, startPeriod, endPeriod);

            AssertNotNullResponse(response);
            if (IsAdditionalPackagePlan)
            {
                AssertErrorMessage(response, "Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.");
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
            else
            {
                AssertErrorMessage(response, "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(RequestException), "EndPeriod is from future.")]
        public void TestIncorrectEndTimeFromFeature()
        {
            var endPeriod = new DateTime(DateTime.Now.Year + 1, 01, 01);
            var response = Manager.Exchanges.Trades.Historical(Symbol, StartPeriod, endPeriod);

            AssertNotNullResponse(response);
            if (IsAdditionalPackagePlan)
            {
                AssertNullErrorMessage(response);
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
            else
            {
                AssertErrorMessage(response, "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(RequestException), "EndPeriod is less than StartPeriod.")]
        public void TestIncorrectTimeInterval()
        {
            var startPeriod = new DateTime(DateTime.Now.Year, 01, 01);
            var endPeriod = new DateTime(DateTime.Now.Year - 1, 01, 01);
            Manager.Exchanges.Trades.Historical(Symbol, startPeriod, endPeriod);
        }

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;

        private Symbol Symbol { get; } = new Symbol("5b7add17b2fc9a000157cc0a");
        private DateTime StartPeriod { get; } = new DateTime(2019, 05, 01);
        private DateTime EndPeriod { get; } = new DateTime(2019, 05, 10);
    }
}