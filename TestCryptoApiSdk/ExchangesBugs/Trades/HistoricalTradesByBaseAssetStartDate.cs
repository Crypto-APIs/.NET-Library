using System;
using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.ExchangesBugs.Trades
{
    [Ignore]
    [TestClass]
    public class HistoricalTradesByBaseAssetStartDate : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Historical(BaseAsset, StartPeriod);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Historical(BaseAsset, StartPeriod, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Historical(BaseAsset, StartPeriod, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.Historical(BaseAsset, StartPeriod, skip, limit);
        }

        [TestMethod]
        public void TestIncorrectStartTimeFromPast()
        {
            var startPeriod = new DateTime(1960, 01, 01);
            var response = Manager.Exchanges.Trades.Historical(BaseAsset, startPeriod);

            if (IsAdditionalPackagePlan)
            {
                AssertErrorMessage(response, "Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.");
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
            else
            {
                AssertErrorMessage(response, "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
            }
        }

        [TestMethod]
        public void TestIncorrectStartTimeFromFeature()
        {
            var startPeriod = new DateTime(DateTime.Now.Year + 1, 01, 01);
            var response = Manager.Exchanges.Trades.Historical(BaseAsset, startPeriod);

            if (IsAdditionalPackagePlan)
            {
                AssertNullErrorMessage(response);
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
            else
            {
                AssertErrorMessage(response, "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
            }
        }

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;
        //protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Asset BaseAsset { get; } = new Asset("5b1ea92e584bf50020130612");
        private DateTime StartPeriod { get; } = new DateTime(2019, 05, 01);
    }
}