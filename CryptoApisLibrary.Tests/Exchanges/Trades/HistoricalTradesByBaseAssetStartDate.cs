using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Trades
{
    [TestClass]
    public class HistoricalTradesByBaseAssetStartDate : BaseCollectionTest
    {
        [TestMethod]
        public void IncorrectStartTimeFromPast_ErrorMessage()
        {
            var baseAsset = Features.Bch;
            var startPeriod = new DateTime(1960, 01, 01);

            var response = Manager.Exchanges.Trades.Historical(baseAsset, startPeriod);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "Your package plan includes only 365 days historical data. Please contact us if you need more or upgrade your plan.");
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
        }

        [TestMethod]
        public void IncorrectStartTimeFromFeature_ErrorMessage()
        {
            var baseAsset = Features.Bch;
            var startPeriod = new DateTime(DateTime.Now.Year + 1, 01, 01);

            var response = Manager.Exchanges.Trades.Historical(baseAsset, startPeriod);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertNullErrorMessage(response);
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
        }

        [Ignore] //todo: random sequence of collection elements with equality "EventTime"
        [TestMethod]
        public override void MainTest()
        { }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Historical(BaseAsset, StartPeriod);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Historical(BaseAsset, StartPeriod, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Historical(BaseAsset, StartPeriod, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.Historical(BaseAsset, StartPeriod, skip, limit);
        }

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;
        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Asset BaseAsset { get; } = Features.Bch;
        private DateTime StartPeriod { get; } = new DateTime(2019, 05, 28);
    }
}