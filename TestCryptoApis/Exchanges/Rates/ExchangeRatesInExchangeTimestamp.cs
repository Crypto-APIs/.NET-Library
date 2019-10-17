using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApis.Exchanges.Rates
{
    [TestClass]
    public class ExchangeRatesInExchangeTimestamp : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, Exchange, TimeStamp);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, Exchange, TimeStamp, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, Exchange, TimeStamp.Date, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, Exchange, TimeStamp, skip, limit);
        }

        [TestMethod]
        public void TestWrongTimestampFromFuture()
        {
            var timeStamp = new DateTime(DateTime.Now.Year + 1, 01, 01);
            var response = Manager.Exchanges.Rates.GetAny(BaseAsset, Exchange, timeStamp);

            AssertNullErrorMessage(response);
            AssertEmptyCollection(nameof(response.Rates), response.Rates);
        }

        [TestMethod]
        public void TestWrongTimestampFromPast()
        {
            var timeStamp = new DateTime(1960, 01, 01);
            var response = Manager.Exchanges.Rates.GetAny(BaseAsset, Exchange, timeStamp);

            AssertErrorMessage(response, "Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.");
            AssertEmptyCollection(nameof(response.Rates), response.Rates);
        }

        private Asset BaseAsset { get; } = Features.Ltc;
        private Exchange Exchange { get; } = Features.Bittrex;
        private DateTime TimeStamp { get; } = new DateTime(2019, 09, 23);
    }
}