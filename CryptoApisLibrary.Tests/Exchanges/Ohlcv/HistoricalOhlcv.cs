using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Ohlcv
{
    [TestClass]
    public class HistoricalOhlcv : BaseCollectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol of null was inappropriately allowed.")]
        public void NullSymbol_Exception()
        {
            Symbol symbol = null;
            var period = new Period("1day");
            var startPeriod = new DateTime(2019, 04, 15);

            Manager.Exchanges.Ohlcv.Historical(symbol, period, startPeriod);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol.Id of null was inappropriately allowed.")]
        public void NullSymbolId_Exception()
        {
            var symbol = new Symbol();
            var period = new Period("1day");
            var startPeriod = new DateTime(2019, 04, 15);

            Manager.Exchanges.Ohlcv.Historical(symbol, period, startPeriod);
        }

        [TestMethod]
        public void UnexistingSymbol_ErrorMessage()
        {
            var symbol = Features.UnexistingSymbol;
            var period = new Period("1day");
            var startPeriod = new DateTime(2019, 04, 15);

            var response = Manager.Exchanges.Ohlcv.Historical(symbol, period, startPeriod);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "Unknown symbol");
                AssertEmptyCollection(nameof(response.Ohlcv), response.Ohlcv);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Period of null was inappropriately allowed.")]
        public void NullPeriod_Exception()
        {
            var symbol = Features.BtcLtc;
            Period period = null;
            var startPeriod = new DateTime(2019, 04, 15);

            Manager.Exchanges.Ohlcv.Historical(symbol, period, startPeriod);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Period.Id of null was inappropriately allowed.")]
        public void NullPeriodId_Exception()
        {
            var symbol = Features.BtcLtc;
            var period = new Period();
            var startPeriod = new DateTime(2019, 04, 15);

            Manager.Exchanges.Ohlcv.Historical(symbol, period, startPeriod);
        }

        [TestMethod]
        public void UnexistingPeriod_ErrorMessage()
        {
            var symbol = Features.BtcLtc;
            var period = new Period("QWEE'WQ");
            var startPeriod = new DateTime(2019, 04, 15);

            var response = Manager.Exchanges.Ohlcv.Historical(symbol, period, startPeriod);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "General Error: period must be in {'1sec', '2sec', '3sec', '4sec', '5sec', '6sec', '10sec', '15sec', '20sec', '30sec', '1min', '2min', '3min', '4min', '5min', '6min', '10min', '15min', '20min', '30min', '1hrs', '2hrs', '3hrs', '4hrs', '6hrs', '8hrs', '12hrs', '1day', '2day', '3day', '5day', '7day', '10day', '1mth', '2mth', '3mth', '4mth', '6mth', '1yrs', '2yrs', '3yrs', '4yrs', '5yrs'}");
                AssertEmptyCollection(nameof(response.Ohlcv), response.Ohlcv);
            }
        }

        [TestMethod]
        public void IncorrectStartTimeFromPast_ErrorMessage()
        {
            var symbol = Features.BtcLtc;
            var period = new Period("QWEE'WQ");
            var startPeriod = new DateTime(1960, 01, 01);

            var response = Manager.Exchanges.Ohlcv.Historical(symbol, period, startPeriod);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response,
                    "Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.");
                AssertEmptyCollection(nameof(response.Ohlcv), response.Ohlcv);
            }
        }

        [TestMethod]
        public void IncorrectStartTimeFromFeature_EmptyResultCollection()
        {
            var symbol = Features.BtcLtc;
            var period = new Period("1day");
            var startPeriod = new DateTime(DateTime.Now.Year + 1, 01, 01);

            var response = Manager.Exchanges.Ohlcv.Historical(symbol, period, startPeriod);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertNullErrorMessage(response);
                AssertEmptyCollection(nameof(response.Ohlcv), response.Ohlcv);
            }
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Ohlcv.Historical(Symbol, Period, StartPeriod);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Ohlcv.Historical(Symbol, Period, StartPeriod, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Ohlcv.Historical(Symbol, Period, StartPeriod, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Ohlcv.Historical(Symbol, Period, StartPeriod, skip, limit);
        }

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;

        private Symbol Symbol { get; } = Features.BtcLtc;
        private Period Period { get; } = new Period("1day");
        private DateTime StartPeriod { get; } = new DateTime(2019, 04, 15);
    }
}