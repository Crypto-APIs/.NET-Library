using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.DataTypes.Exceptions;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class GetLatestData : BaseCollectionTestWithoutSkip
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.GetLatestData(Symbol, Period);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.GetLatestData(Symbol, Period, limit: limit);
        }

        [Ignore] // #002
        [TestMethod]
        public override void MainTest()
        {
            // Remove after fixing #023 this method.
        }

        [TestMethod]
        [ExpectedException(typeof(RequestException), "A Symbol of null was inappropriately allowed.")]
        public void TestUndefinedSymbol()
        {
            var period = new Period("1day");
            Manager.Exchanges.GetLatestData(symbol: null, period: period);
        }

        [TestMethod]
        public void TestIncorrectSymbol()
        {
            var symbol = new Symbol("QWEEWQ1");
            var period = new Period("1day");
            var response = Manager.Exchanges.GetLatestData(symbol, period);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Ohlcv);
            Assert.IsFalse(response.Ohlcv.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(RequestException), "A Period of null was inappropriately allowed.")]
        public void TestUndefinedPeriod()
        {
            Manager.Exchanges.GetLatestData(Symbol, period: null);
        }

        [TestMethod]
        public void TestIncorrectPeriod()
        {
            var period = new Period("QWE");
            var response = Manager.Exchanges.GetLatestData(Symbol, period);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("General Error: period must be in {'1sec', '2sec', '3sec', '4sec', '5sec', '6sec', '10sec', '15sec', '20sec', '30sec', '1min', '2min', '3min', '4min', '5min', '6min', '10min', '15min', '20min', '30min', '1hrs', '2hrs', '3hrs', '4hrs', '6hrs', '8hrs', '12hrs', '1day', '2day', '3day', '5day', '7day', '10day', '1mth', '2mth', '3mth', '4mth', '6mth', '1yrs', '2yrs', '3yrs', '4yrs', '5yrs'}", response.ErrorMessage);
            Assert.IsNotNull(response.Ohlcv);
            Assert.IsFalse(response.Ohlcv.Any());
        }

        private Symbol Symbol { get; } = new Symbol("5b7add17b2fc9a000157cc0b");
        private Period Period { get; } = new Period("1day");
    }
}