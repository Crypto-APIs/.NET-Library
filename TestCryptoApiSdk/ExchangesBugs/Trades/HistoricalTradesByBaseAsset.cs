using System;
using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.ExchangesBugs.Trades
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
            return Manager.Exchanges.Trades.Historical(BaseAsset, skip: skip);
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
            Manager.Exchanges.Trades.Historical(baseAsset: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset.Id of null was inappropriately allowed.")]
        public void TestNullBaseAssetId()
        {
            Manager.Exchanges.Trades.Historical(new Asset());
        }

        [TestMethod]
        public void TestIncorrectBaseAsset()
        {
            var baseAsset = new Asset("QWE'EWQ1");
            var response = Manager.Exchanges.Trades.Historical(baseAsset);

            if (IsAdditionalPackagePlan)
            {
                AssertErrorMessage(response, "We are facing technical issues, please try again later");
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
    }
}