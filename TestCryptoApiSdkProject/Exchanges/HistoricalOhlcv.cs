using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.DataTypes.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCryptoApiSdkProject.Exchanges
{
    // todo: "BaseCollectionTest" is must be parent of this class
    [TestClass]
    public class HistoricalOhlcv : BaseTest
    {
        private const string SymbolId = "5bfc325d9c40a100014db901";

        [Ignore] // todo: #008
        [TestMethod]
        public void TestSimple()
        {
            var symbol = new Symbol(SymbolId);
            var period = new Period("1day");
            var startPeriod = new DateTime(2019, 04, 15);

            var allSymbols = Manager.Exchanges.Symbols(0, 20000);
            for (var i = 0; i <= 10000; i++)
            {
                var id = allSymbols.Symbols[i].Id;
                var responseTemp = Manager.Exchanges.HistoricalOhlcv(new Symbol(id), period, startPeriod);
                if (responseTemp != null && responseTemp.Ohlcv.Any())
                {
                    break;
                }
            }

            var response = Manager.Exchanges.HistoricalOhlcv(symbol, period, startPeriod);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsNotNull(response.Ohlcv);
                Assert.IsTrue(response.Ohlcv.Any());

                AllHistoricalDataSingleton.Instance.OHLCV = response.Ohlcv;
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [Ignore] //todo: #008
        [TestMethod]
        public void TestLimit()
        {
            var symbol = new Symbol(SymbolId);
            var period = new Period("1day");
            var startPeriod = new DateTime(2019, 02, 04);
            var response = Manager.Exchanges.HistoricalOhlcv(symbol, period, startPeriod, limit: 2);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsNotNull(response.Ohlcv);
                Assert.AreEqual(2, response.Ohlcv.Count);

                if (AllHistoricalDataSingleton.Instance.OHLCV != null)
                {
                    var allLatestData = AllHistoricalDataSingleton.Instance.OHLCV;
                    Assert.AreEqual(allLatestData[0], response.Ohlcv[0]);
                    Assert.AreEqual(allLatestData[1], response.Ohlcv[1]);
                }
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Limit was inappropriately allowed.")]
        public void TestLimitOutOfRange()
        {
            var symbol = new Symbol(SymbolId);
            var period = new Period("1day");
            var startPeriod = new DateTime(2019, 02, 04);
            Manager.Exchanges.HistoricalOhlcv(symbol, period, startPeriod, limit: 0);
        }

        [Ignore] // todo: #008
        [TestMethod]
        public void TestStartFinish()
        {
            var symbol = new Symbol(SymbolId);
            var period = new Period("6hrs");
            var startPeriod = new DateTime(2019, 02, 04);
            var endPeriod = new DateTime(2019, 02, 05);
            var response = Manager.Exchanges.HistoricalOhlcv(symbol, period, startPeriod, endPeriod);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsNotNull(response.Ohlcv);
                Assert.AreEqual(2, response.Ohlcv.Count);

                if (AllHistoricalDataSingleton.Instance.OHLCV != null)
                {
                    var allLatestData = AllHistoricalDataSingleton.Instance.OHLCV;
                    Assert.AreEqual(allLatestData[0], response.Ohlcv[0]);
                    Assert.AreEqual(allLatestData[1], response.Ohlcv[1]);
                }
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(RequestException), "A Symbol of null was inappropriately allowed.")]
        public void TestUndefinedSymbol()
        {
            var period = new Period("1day");
            var startPeriod = new DateTime(2019, 02, 04);
            Manager.Exchanges.HistoricalOhlcv(symbol: null, period: period, startPeriod: startPeriod);
        }

        [TestMethod]
        public void TestIncorrectSymbol()
        {
            var symbol = new Symbol("QWEEWQ1");
            var period = new Period("1day");
            var startPeriod = new DateTime(2019, 02, 04);
            var response = Manager.Exchanges.HistoricalOhlcv(symbol, period, startPeriod);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsNotNull(response.Ohlcv);
                Assert.IsFalse(response.Ohlcv.Any());
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(RequestException), "A Period of null was inappropriately allowed.")]
        public void TestUndefinedPeriod()
        {
            var symbol = new Symbol(SymbolId);
            var startPeriod = new DateTime(2019, 02, 04);
            Manager.Exchanges.HistoricalOhlcv(symbol, period: null, startPeriod: startPeriod);
        }

        [TestMethod]
        public void TestIncorrectPeriod()
        {
            var symbol = new Symbol(SymbolId);
            var period = new Period("QWE");
            var startPeriod = new DateTime(2019, 02, 04);
            var response = Manager.Exchanges.HistoricalOhlcv(symbol, period, startPeriod);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual("General Error: period must be in {'1sec', '2sec', '3sec', '4sec', '5sec', '6sec', '10sec', '15sec', '20sec', '30sec', '1min', '2min', '3min', '4min', '5min', '6min', '10min', '15min', '20min', '30min', '1hrs', '2hrs', '3hrs', '4hrs', '6hrs', '8hrs', '12hrs', '1day', '2day', '3day', '5day', '7day', '10day', '1mth', '2mth', '3mth', '4mth', '6mth', '1yrs', '2yrs', '3yrs', '4yrs', '5yrs'}", response.ErrorMessage);
                Assert.IsNotNull(response.Ohlcv);
                Assert.IsFalse(response.Ohlcv.Any());
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestIncorrectStartTimeFromPast()
        {
            var symbol = new Symbol(SymbolId);
            var period = new Period("1day");
            var startPeriod = new DateTime(1960, 01, 01);
            var response = Manager.Exchanges.HistoricalOhlcv(symbol, period, startPeriod);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual("Your package plan includes only 360 days historical data. Please contact us if you need more or upgrade your plan.", response.ErrorMessage);
                Assert.IsNotNull(response.Ohlcv);
                Assert.IsFalse(response.Ohlcv.Any());
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestIncorrectStartTimeFromFeature()
        {
            var symbol = new Symbol(SymbolId);
            var period = new Period("1day");
            var startPeriod = new DateTime(DateTime.Now.Year + 1, 01, 01);
            var response = Manager.Exchanges.HistoricalOhlcv(symbol, period, startPeriod);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage)); // it is a corrected behavior
                Assert.IsNotNull(response.Ohlcv);
                Assert.IsFalse(response.Ohlcv.Any());
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        private class AllHistoricalDataSingleton
        {
            private static AllHistoricalDataSingleton _instance;
            public static AllHistoricalDataSingleton Instance => _instance ?? (_instance = new AllHistoricalDataSingleton());

            public List<Ohlcv> OHLCV { get; set; }
        }
    }
}