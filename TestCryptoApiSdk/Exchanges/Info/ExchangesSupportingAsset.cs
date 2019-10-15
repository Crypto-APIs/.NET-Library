using System;
using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Exchanges.Info
{
    [Ignore]
    [TestClass]
    public class ExchangesSupportingAsset : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Info.ExchangesSupportingAsset(Asset);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Info.ExchangesSupportingAsset(Asset, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Info.ExchangesSupportingAsset(Asset, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Info.ExchangesSupportingAsset(Asset, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset of null was inappropriately allowed.")]
        public void TestNullAsset()
        {
            Manager.Exchanges.Info.ExchangesSupportingAsset(asset: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Asset.Id of null was inappropriately allowed.")]
        public void TestNullId()
        {
            Manager.Exchanges.Info.ExchangesSupportingAsset(new Asset());
        }

        [TestMethod]
        public void TestIncorrectAsset()
        {
            var asset = new Asset("QWEEWQ1");
            var response = Manager.Exchanges.Info.ExchangesSupportingAsset(asset);

            AssertNullErrorMessage(response);
            AssertEmptyCollection(nameof(response.Infos), response.Infos);
        }

        private Asset Asset { get; } = new Asset("5b1ea92e584bf50020130612");
    }
}