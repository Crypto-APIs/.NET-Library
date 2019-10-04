using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.DataTypes.Exceptions;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdkProject.Exchanges.Trades
{
    [TestClass]
    public class HistoricalTrades : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.HistoricalTrades(Symbol);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.HistoricalTrades(Symbol, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.HistoricalTrades(Symbol, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.HistoricalTrades(Symbol, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(RequestException), "A Symbol of null was inappropriately allowed.")]
        public void TestUndefinedSymbol()
        {
            Manager.Exchanges.Trades.HistoricalTrades(symbol: null);
        }

        [TestMethod]
        public void TestIncorrectSymbol()
        {
            var symbol = new Symbol("QWEEWQ1");
            var response = Manager.Exchanges.Trades.HistoricalTrades(symbol);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.AreEqual("Unknown symbol", response.ErrorMessage);
                Assert.IsNotNull(response.Trades);
                Assert.IsFalse(response.Trades.Any());
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
        [ExpectedException(typeof(RequestException), "EndPeriod is less than StartPeriod.")]
        public void TestIncorrectTimeInterval()
        {
            var startPeriod = new DateTime(DateTime.Now.Year, 01, 01);
            var endPeriod = new DateTime(DateTime.Now.Year - 1, 01, 01);
            Manager.Exchanges.Trades.HistoricalTrades(Symbol, startPeriod, endPeriod);
        }

        [TestMethod]
        public void TestIncorrectStartTimeFromPast()
        {
            var startPeriod = new DateTime(1960, 01, 01);
            var endPeriod = new DateTime(1961, 01, 01);
            var response = Manager.Exchanges.Trades.HistoricalTrades(Symbol, startPeriod, endPeriod);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual("Your package plan includes only 360 days historical data. Please contact us if you need more or upgrade your plan.", response.ErrorMessage);
                Assert.IsNotNull(response.Trades);
                Assert.IsFalse(response.Trades.Any());
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
        [ExpectedException(typeof(RequestException), "StartPeriod is from future.")]
        public void TestIncorrectStartTimeFromFeature()
        {
            var startPeriod = new DateTime(DateTime.Now.Year + 1, 01, 01);
            Manager.Exchanges.Trades.HistoricalTrades(Symbol, startPeriod);
        }

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;
        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Symbol Symbol { get; } = new Symbol("5b7add17b2fc9a000157cc0a");
    }
}