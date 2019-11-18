using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Info
{
    [TestClass]
    public class ExchangesSupportingPairs : BaseCollectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset1 of null was inappropriately allowed.")]
        public void NullFirstAsset_Exception()
        {
            Asset asset1 = null;
            var asset2 = Features.Eth;

            Manager.Exchanges.Info.ExchangesSupportingPairs(asset1, asset2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset1.Id of null was inappropriately allowed.")]
        public void NullFirstAssetId_Exception()
        {
            var asset1 = new Asset();
            var asset2 = Features.Eth;

            Manager.Exchanges.Info.ExchangesSupportingPairs(asset1, asset2);
        }

        [TestMethod]
        public void UnexistingFirstAsset_EmptyResultCollection()
        {
            var asset1 = Features.UnexistingAsset;
            var asset2 = Features.Eth;

            var response = Manager.Exchanges.Info.ExchangesSupportingPairs(asset1, asset2);

            AssertNullErrorMessage(response);
            AssertEmptyCollection(nameof(response.Infos), response.Infos);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset2 of null was inappropriately allowed.")]
        public void NullSecondAsset_Exception()
        {
            var asset1 = Features.Btc;
            Asset asset2 = null;

            Manager.Exchanges.Info.ExchangesSupportingPairs(asset1, asset2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset2.Id of null was inappropriately allowed.")]
        public void NullSecondAssetId_Exception()
        {
            var asset1 = Features.Btc;
            var asset2 = new Asset();

            Manager.Exchanges.Info.ExchangesSupportingPairs(asset1, asset2);
        }

        [TestMethod]
        public void UnexistingSecondAsset_EmptyResultCollection()
        {
            var asset1 = Features.Btc;
            var asset2 = Features.UnexistingAsset;

            var response = Manager.Exchanges.Info.ExchangesSupportingPairs(asset1, asset2);

            AssertNullErrorMessage(response);
            AssertEmptyCollection(nameof(response.Infos), response.Infos);
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Info.ExchangesSupportingPairs(Asset1, Asset2);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Info.ExchangesSupportingPairs(Asset1, Asset2, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Info.ExchangesSupportingPairs(Asset1, Asset2, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Info.ExchangesSupportingPairs(Asset1, Asset2, skip, limit);
        }

        private Asset Asset1 { get; } = Features.Btc;
        private Asset Asset2 { get; } = Features.Eth;
    }
}