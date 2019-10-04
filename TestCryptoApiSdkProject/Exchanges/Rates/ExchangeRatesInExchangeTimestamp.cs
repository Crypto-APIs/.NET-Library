using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdkProject.Exchanges.Rates
{
    [TestClass]
    public class ExchangeRatesInExchangeTimestamp : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Rates.ExchangeRates(BaseAsset, Exchange, TimeStamp);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Rates.ExchangeRates(BaseAsset, Exchange, TimeStamp, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Rates.ExchangeRates(BaseAsset, Exchange, TimeStamp.Date, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Rates.ExchangeRates(BaseAsset, Exchange, TimeStamp, skip, limit);
        }

        [TestMethod]
        public void TestWrongTimestampFromFuture()
        {
            var timeStamp = new DateTime(DateTime.Now.Year + 1, 01, 01);
            var response = Manager.Exchanges.Rates.ExchangeRates(BaseAsset, Exchange, timeStamp);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Rates);
            Assert.IsFalse(response.Rates.Any());
        }

        [TestMethod]
        public void TestWrongTimestampFromPast()
        {
            var timeStamp = new DateTime(1960, 01, 01);
            var response = Manager.Exchanges.Rates.ExchangeRates(BaseAsset, Exchange, timeStamp);

            Assert.IsNotNull(response);
            Assert.AreEqual("Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.", response.ErrorMessage);
            Assert.IsNotNull(response.Rates);
            Assert.IsFalse(response.Rates.Any());
        }

        private Asset BaseAsset { get; } = new Asset("5b755dacd5dd99000b3d92b2");
        private Exchange Exchange { get; } = new Exchange("5b1ea9d21090c200146f7366");
        private DateTime TimeStamp { get; } = new DateTime(2019, 02, 03);
    }
}