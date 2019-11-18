using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Rates
{
    [TestClass]
    public class ExchangeRatesTimeStamp : BaseCollectionTest
    {
        [TestMethod]
        public void WrongTimestampFromFuture_EmptyResultCollection()
        {
            var baseAsset = Features.Ltc;
            var timeStamp = new DateTime(DateTime.Now.Year + 1, 01, 01);

            var response = Manager.Exchanges.Rates.GetAny(baseAsset, timeStamp);

            AssertNullErrorMessage(response);
            AssertEmptyCollection(nameof(response.Rates), response.Rates);
        }

        [TestMethod]
        public void WrongTimestampFromPast_ErrorMessage()
        {
            var baseAsset = Features.Ltc;
            var timeStamp = new DateTime(1960, 01, 01);

            var response = Manager.Exchanges.Rates.GetAny(baseAsset, timeStamp);

            AssertErrorMessage(response,
                "Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.");
            AssertEmptyCollection(nameof(response.Rates), response.Rates);
        }

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

        private Asset BaseAsset { get; } = Features.Ltc;
        private DateTime TimeStamp { get; } = new DateTime(2019, 02, 03);
    }
}