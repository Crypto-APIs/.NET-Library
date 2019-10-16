using System;
using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Exchanges.Trades
{
    [Ignore]
    [TestClass]
    public class HistoricalTradesByBaseAsset : BaseCollectionTest
    {
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset of null was inappropriately allowed.")]
        public void TestNullBaseAsset()
        {
            Asset baseAsset = null;
            Manager.Exchanges.Trades.Historical(baseAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset.Id of null was inappropriately allowed.")]
        public void TestNullBaseAssetId()
        {
            var baseAsset = new Asset();
            Manager.Exchanges.Trades.Historical(baseAsset);
        }

        [TestMethod]
        public void TestIncorrectBaseAsset()
        {
            var baseAsset = Features.UnexistingAsset;
            var response = Manager.Exchanges.Trades.Historical(baseAsset);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "We are facing technical issues, please try again later");
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
        }

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;
        //protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Asset BaseAsset { get; } = Features.Bch;
    }
}