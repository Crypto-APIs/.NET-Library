using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApis.Exchanges.Ohlcv
{
    [TestClass]
    public class HistoricalOhlcvByExchange : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Ohlcv.Historical(Exchange, Period, StartPeriod);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Ohlcv.Historical(Exchange, Period, StartPeriod, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Ohlcv.Historical(Exchange, Period, StartPeriod, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Ohlcv.Historical(Exchange, Period, StartPeriod, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void TestNullExchange()
        {
            Exchange exchange = null;
            Manager.Exchanges.Ohlcv.Historical(exchange, Period, StartPeriod);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void TestNullExchangeId()
        {
            var exchange = new Exchange();
            Manager.Exchanges.Ohlcv.Historical(exchange, Period, StartPeriod);
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var exchange = Features.UnexistingExchange;
            var response = Manager.Exchanges.Ohlcv.Historical(exchange, Period, StartPeriod);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "We are facing technical issues, please try again later");
                AssertEmptyCollection(nameof(response.Ohlcv), response.Ohlcv);
            }
        }

        [TestMethod]
        public void TestIncorrectPeriod()
        {
            var period = new Period("QWEE'WQ");
            var response = Manager.Exchanges.Ohlcv.Historical(Exchange, period, StartPeriod);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "General Error: period must be in {'1sec', '2sec', '3sec', '4sec', '5sec', '6sec', '10sec', '15sec', '20sec', '30sec', '1min', '2min', '3min', '4min', '5min', '6min', '10min', '15min', '20min', '30min', '1hrs', '2hrs', '3hrs', '4hrs', '6hrs', '8hrs', '12hrs', '1day', '2day', '3day', '5day', '7day', '10day', '1mth', '2mth', '3mth', '4mth', '6mth', '1yrs', '2yrs', '3yrs', '4yrs', '5yrs'}");
                AssertEmptyCollection(nameof(response.Ohlcv), response.Ohlcv);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Period of null was inappropriately allowed.")]
        public void TestNullPeriod()
        {
            Period period = null;
            Manager.Exchanges.Ohlcv.Historical(Exchange, period, StartPeriod);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Period.Id of null was inappropriately allowed.")]
        public void TestNullPeriodId()
        {
            var period = new Period();
            Manager.Exchanges.Ohlcv.Historical(Exchange, period, StartPeriod);
        }

        [TestMethod]
        public void TestIncorrectStartTimeFromPast()
        {
            var startPeriod = new DateTime(1960, 01, 01);
            var response = Manager.Exchanges.Ohlcv.Historical(Exchange, Period, startPeriod);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response,
                    "Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.");
                AssertEmptyCollection(nameof(response.Ohlcv), response.Ohlcv);
            }
        }

        [TestMethod]
        public void TestIncorrectStartTimeFromFeature()
        {
            var startPeriod = new DateTime(DateTime.Now.Year + 1, 01, 01);
            var response = Manager.Exchanges.Ohlcv.Historical(Exchange, Period, startPeriod);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertNullErrorMessage(response);
                AssertEmptyCollection(nameof(response.Ohlcv), response.Ohlcv);
            }
        }

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;

        private Exchange Exchange { get; } = Features.Bittrex;
        private Period Period { get; } = new Period("1day");
        private DateTime StartPeriod { get; } = new DateTime(2019, 04, 15);
    }
}