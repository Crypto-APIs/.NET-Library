using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdk.Exchanges.Ohlcv
{
    [TestClass]
    public class LatestOhlcv : BaseCollectionTestWithoutSkip
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Ohlcv.Latest(Symbol, Period);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Ohlcv.Latest(Symbol, Period, limit: limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol of null was inappropriately allowed.")]
        public void TestNullSymbol()
        {
            Manager.Exchanges.Ohlcv.Latest(symbol: null, period: Period);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol of null was inappropriately allowed.")]
        public void TestNullSymbolId()
        {
            Manager.Exchanges.Ohlcv.Latest(new Symbol(), Period);
        }

        [TestMethod]
        public void TestIncorrectSymbol()
        {
            var symbol = new Symbol("QWE'EWQ1");
            var period = new Period("1day");
            var response = Manager.Exchanges.Ohlcv.Latest(symbol, period);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "Unknown symbol");
            AssertEmptyCollection(nameof(response.Ohlcv), response.Ohlcv);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Period of null was inappropriately allowed.")]
        public void TestNullPeriod()
        {
            Manager.Exchanges.Ohlcv.Latest(Symbol, period: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Period.Id of null was inappropriately allowed.")]
        public void TestNullPeriodId()
        {
            Manager.Exchanges.Ohlcv.Latest(Symbol, new Period());
        }

        [TestMethod]
        public void TestIncorrectPeriod()
        {
            var period = new Period("QW'E");
            var response = Manager.Exchanges.Ohlcv.Latest(Symbol, period);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "General Error: period must be in {'1sec', '2sec', '3sec', '4sec', '5sec', '6sec', '10sec', '15sec', '20sec', '30sec', '1min', '2min', '3min', '4min', '5min', '6min', '10min', '15min', '20min', '30min', '1hrs', '2hrs', '3hrs', '4hrs', '6hrs', '8hrs', '12hrs', '1day', '2day', '3day', '5day', '7day', '10day', '1mth', '2mth', '3mth', '4mth', '6mth', '1yrs', '2yrs', '3yrs', '4yrs', '5yrs'}");
            AssertEmptyCollection(nameof(response.Ohlcv), response.Ohlcv);
        }

        private Symbol Symbol { get; } = new Symbol("5b7add17b2fc9a000157cc0b");
        private Period Period { get; } = new Period("1day");
    }
}