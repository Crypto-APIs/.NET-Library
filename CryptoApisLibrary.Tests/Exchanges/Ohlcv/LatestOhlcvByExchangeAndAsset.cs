using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Ohlcv
{
    [TestClass]
    public class LatestOhlcvByExchangeAndAsset : BaseCollectionTestWithoutSkip
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Exchange of null was inappropriately allowed.")]
        public void NullExchange_Exception()
        {
            Exchange exchange = null;
            var asset = Features.Btc;
            var period = new Period("1day");

            Manager.Exchanges.Ohlcv.Latest(exchange, asset, period);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Exchange.Id of null was inappropriately allowed.")]
        public void NullExchangeId_Exception()
        {
            var exchange = new Exchange();
            var asset = Features.Btc;
            var period = new Period("1day");

            Manager.Exchanges.Ohlcv.Latest(exchange, asset, period);
        }

        [TestMethod]
        public void UnexistingExchange_ErrorMessage()
        {
            var exchange = Features.UnexistingExchange;
            var asset = Features.Btc;
            var period = new Period("1day");

            var response = Manager.Exchanges.Ohlcv.Latest(exchange, asset, period);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Ohlcv), response.Ohlcv);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Period of null was inappropriately allowed.")]
        public void NullPeriod_Exception()
        {
            var exchange = Features.Bittrex;
            var asset = Features.Btc;
            Period period = null;

            Manager.Exchanges.Ohlcv.Latest(exchange, asset, period);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Period.Id of null was inappropriately allowed.")]
        public void NullPeriodId_Exception()
        {
            var exchange = Features.Bittrex;
            var asset = Features.Btc;
            var period = new Period();

            Manager.Exchanges.Ohlcv.Latest(exchange, asset, period);
        }

        [TestMethod]
        public void UnexistingPeriod_ErrorMessage()
        {
            var exchange = Features.Bittrex;
            var asset = Features.Btc;
            var period = new Period("QW'E");
            
            var response = Manager.Exchanges.Ohlcv.Latest(exchange, asset, period);

            AssertErrorMessage(response, "General Error: period must be in {'1sec', '2sec', '3sec', '4sec', '5sec', '6sec', '10sec', '15sec', '20sec', '30sec', '1min', '2min', '3min', '4min', '5min', '6min', '10min', '15min', '20min', '30min', '1hrs', '2hrs', '3hrs', '4hrs', '6hrs', '8hrs', '12hrs', '1day', '2day', '3day', '5day', '7day', '10day', '1mth', '2mth', '3mth', '4mth', '6mth', '1yrs', '2yrs', '3yrs', '4yrs', '5yrs'}");
            AssertEmptyCollection(nameof(response.Ohlcv), response.Ohlcv);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset of null was inappropriately allowed.")]
        public void NullAsset_Exception()
        {
            var exchange = Features.Bittrex;
            Asset asset = null;
            var period = new Period("1day");

            Manager.Exchanges.Ohlcv.Latest(exchange, asset, period);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset.Id of null was inappropriately allowed.")]
        public void NullAssetId_Exception()
        {
            var exchange = Features.Bittrex;
            var asset = new Asset();
            var period = new Period("1day");

            Manager.Exchanges.Ohlcv.Latest(exchange, asset, period);
        }


        [TestMethod]
        public void UnexistingAsset_ErrorMessage()
        {
            var exchange = Features.Bittrex;
            var asset = Features.UnexistingAsset;
            var period = new Period("1day");

            var response = Manager.Exchanges.Ohlcv.Latest(exchange, asset, period);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Ohlcv), response.Ohlcv);
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Ohlcv.Latest(Exchange, Asset, Period);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Ohlcv.Latest(Exchange, Asset, Period, limit: limit);
        }

        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Exchange Exchange { get; } = Features.Bittrex;
        private Asset Asset { get; } = Features.Btc;
        private Period Period { get; } = new Period("1day");
    }
}