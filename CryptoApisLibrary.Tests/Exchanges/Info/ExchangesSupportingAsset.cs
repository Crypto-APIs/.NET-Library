using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Exchanges.Info
{
    [TestClass]
    public class ExchangesSupportingAsset : BaseCollectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset of null was inappropriately allowed.")]
        public void NullAsset_Exception()
        {
            Asset asset = null;

            Manager.Exchanges.Info.ExchangesSupportingAsset(asset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Asset.Id of null was inappropriately allowed.")]
        public void NullAssetId_Exception()
        {
            var asset = new Asset();

            Manager.Exchanges.Info.ExchangesSupportingAsset(asset);
        }

        [TestMethod]
        public void UnexistingAsset_EmptyResultCollection()
        {
            var asset = Features.UnexistingAsset;

            var response = Manager.Exchanges.Info.ExchangesSupportingAsset(asset);

            AssertNullErrorMessage(response);
            AssertEmptyCollection(nameof(response.Infos), response.Infos);
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Info.ExchangesSupportingAsset(Asset);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Info.ExchangesSupportingAsset(Asset, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Info.ExchangesSupportingAsset(Asset, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Info.ExchangesSupportingAsset(Asset, skip, limit);
        }

        private Asset Asset { get; } = Features.Dash;
    }
}