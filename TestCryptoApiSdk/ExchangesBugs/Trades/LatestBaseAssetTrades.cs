using System;
using System.Diagnostics;
using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.ExchangesBugs.Trades
{
    [TestClass]
    public class LatestBaseAssetTrades : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Latest(BaseAsset);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Latest(BaseAsset, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Latest(BaseAsset, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            Debug.Assert(Skip.HasValue);
            Debug.Assert(Limit.HasValue);
            return Manager.Exchanges.Trades.Latest(BaseAsset, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset of null was inappropriately allowed.")]
        public void TestNullAsset()
        {
            Manager.Exchanges.Trades.Latest(baseAsset: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset.Id of null was inappropriately allowed.")]
        public void TestNullAssetId()
        {
            Manager.Exchanges.Trades.Latest(new Asset());
        }

        [TestMethod]
        public void TestIncorrectBaseAsset()
        {
            var baseAsset = new Asset("QWE'EWQ1");
            var response = Manager.Exchanges.Trades.Latest(baseAsset);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        private Asset BaseAsset { get; } = new Asset("5b1ea92e584bf50020130612");
    }
}