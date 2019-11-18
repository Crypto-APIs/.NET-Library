using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Trades
{
    [TestClass]
    public class LatestBaseAssetTrades : BaseCollectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset of null was inappropriately allowed.")]
        public void NullAsset_Exception()
        {
            Asset baseAsset = null;

            Manager.Exchanges.Trades.Latest(baseAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset.Id of null was inappropriately allowed.")]
        public void NullAssetId_Exception()
        {
            var baseAsset = new Asset();

            Manager.Exchanges.Trades.Latest(baseAsset);
        }

        [TestMethod]
        public void UnexistingAsset_ErrorMessage()
        {
            var baseAsset = Features.UnexistingAsset;

            var response = Manager.Exchanges.Trades.Latest(baseAsset);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        [Ignore] //todo: random sequence of collection elements with equality "EventTime"
        [TestMethod]
        public override void MainTest()
        { }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Latest(BaseAsset);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Latest(BaseAsset, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Latest(BaseAsset, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.Latest(BaseAsset, skip, limit);
        }

        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Asset BaseAsset { get; } = Features.Btc;
    }
}