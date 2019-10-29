using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApis.Exchanges.Ohlcv
{
    [TestClass]
    public class LatestOhlcvByExchangeAndAsset : BaseCollectionTestWithoutSkip
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Ohlcv.Latest(Exchange, Asset, Period);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Ohlcv.Latest(Exchange, Asset, Period, limit: limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Exchange of null was inappropriately allowed.")]
        public void TestNullExchange()
        {
            Exchange exchange = null;
            Manager.Exchanges.Ohlcv.Latest(exchange, Asset, Period);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Exchange.Id of null was inappropriately allowed.")]
        public void TestNullExchangeId()
        {
            var exchange = new Exchange();
            Manager.Exchanges.Ohlcv.Latest(exchange, Asset, Period);
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var exchange = Features.UnexistingExchange;
            var period = new Period("1day");
            var response = Manager.Exchanges.Ohlcv.Latest(exchange, Asset, period);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Ohlcv), response.Ohlcv);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset of null was inappropriately allowed.")]
        public void TestNullAsset()
        {
            Asset asset = null;
            Manager.Exchanges.Ohlcv.Latest(Exchange, asset, Period);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset.Id of null was inappropriately allowed.")]
        public void TestNullAssetId()
        {
            var asset = new Asset();
            Manager.Exchanges.Ohlcv.Latest(Exchange, asset, Period);
        }

        [TestMethod]
        public void TestIncorrectAsset()
        {
            var asset = Features.UnexistingAsset;
            var period = new Period("1day");
            var response = Manager.Exchanges.Ohlcv.Latest(Exchange, asset, period);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Ohlcv), response.Ohlcv);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Period of null was inappropriately allowed.")]
        public void TestNullPeriod()
        {
            Period period = null;
            Manager.Exchanges.Ohlcv.Latest(Exchange, Asset, period);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Period.Id of null was inappropriately allowed.")]
        public void TestNullPeriodId()
        {
            var period = new Period();
            Manager.Exchanges.Ohlcv.Latest(Exchange, Asset, period);
        }

        [TestMethod]
        public void TestIncorrectPeriod()
        {
            var period = new Period("QW'E");
            var response = Manager.Exchanges.Ohlcv.Latest(Exchange, Asset, period);

            AssertErrorMessage(response, "General Error: period must be in {'1sec', '2sec', '3sec', '4sec', '5sec', '6sec', '10sec', '15sec', '20sec', '30sec', '1min', '2min', '3min', '4min', '5min', '6min', '10min', '15min', '20min', '30min', '1hrs', '2hrs', '3hrs', '4hrs', '6hrs', '8hrs', '12hrs', '1day', '2day', '3day', '5day', '7day', '10day', '1mth', '2mth', '3mth', '4mth', '6mth', '1yrs', '2yrs', '3yrs', '4yrs', '5yrs'}");
            AssertEmptyCollection(nameof(response.Ohlcv), response.Ohlcv);
        }

        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Exchange Exchange { get; } = Features.Bittrex;
        private Asset Asset { get; } = Features.Btc;
        private Period Period { get; } = new Period("1day");
    }
}