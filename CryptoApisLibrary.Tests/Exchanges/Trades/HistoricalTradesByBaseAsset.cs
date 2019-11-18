using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Trades
{
    [TestClass]
    public class HistoricalTradesByBaseAsset : BaseCollectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset of null was inappropriately allowed.")]
        public void NullBaseAsset_Exception()
        {
            Asset baseAsset = null;

            Manager.Exchanges.Trades.Historical(baseAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset.Id of null was inappropriately allowed.")]
        public void NullBaseAssetId_Exception()
        {
            var baseAsset = new Asset();

            Manager.Exchanges.Trades.Historical(baseAsset);
        }

        [TestMethod]
        public void UnexistingAsset_ErrorMessage()
        {
            var baseAsset = Features.UnexistingAsset;

            var response = Manager.Exchanges.Trades.Historical(baseAsset);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "General validation error: Wrong ID format for baseAsset");
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
        }

        [Ignore] //todo: random sequence of collection elements with equality "EventTime"
        [TestMethod]
        public override void MainTest()
        { }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Historical(BaseAsset);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Historical(BaseAsset, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Historical(BaseAsset, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.Historical(BaseAsset, skip, limit);
        }

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;
        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Asset BaseAsset { get; } = Features.Bch;
    }
}