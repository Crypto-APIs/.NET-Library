using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Exchanges.Rates
{
    [Ignore] // todo: note #4
    [TestClass]
    public class ExchangeRatesTimeStamp : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, TimeStamp);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, TimeStamp, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, TimeStamp, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, TimeStamp, skip, limit);
        }

        [TestMethod]
        public void TestWrongTimestampFromFuture()
        {
            var timeStamp = new DateTime(DateTime.Now.Year + 1, 01, 01);
            var response = Manager.Exchanges.Rates.GetAny(BaseAsset, timeStamp);

            AssertNullErrorMessage(response);
            AssertEmptyCollection(nameof(response.Rates), response.Rates);
        }

        [TestMethod]
        public void TestWrongTimestampFromPast()
        {
            var timeStamp = new DateTime(1960, 01, 01);
            var response = Manager.Exchanges.Rates.GetAny(BaseAsset, timeStamp);

            AssertErrorMessage(response,
                "Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.");
            AssertEmptyCollection(nameof(response.Rates), response.Rates);
        }

        private Asset BaseAsset { get; } = Features.Ltc;
        private DateTime TimeStamp { get; } = new DateTime(2019, 02, 03);
    }
}