using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Exchanges.Info
{
    [TestClass]
    public class ExchangesSupportingPairs : BaseCollectionTest
    {
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset1 of null was inappropriately allowed.")]
        public void TestNullAsset1()
        {
            Asset asset1 = null;
            Manager.Exchanges.Info.ExchangesSupportingPairs(asset1, Asset2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset2 of null was inappropriately allowed.")]
        public void TestNullAsset2()
        {
            Asset asset2 = null;
            Manager.Exchanges.Info.ExchangesSupportingPairs(Asset1, asset2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset1.Id of null was inappropriately allowed.")]
        public void TestNullId1()
        {
            var asset1 = new Asset();
            Manager.Exchanges.Info.ExchangesSupportingPairs(asset1, Asset2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset2.Id of null was inappropriately allowed.")]
        public void TestNullId2()
        {
            var asset2 = new Asset();
            Manager.Exchanges.Info.ExchangesSupportingPairs(Asset1, asset2);
        }

        [TestMethod]
        public void TestIncorrectAsset1()
        {
            var asset1 = Features.UnexistingAsset;
            var response = Manager.Exchanges.Info.ExchangesSupportingPairs(asset1, Asset2);

            AssertNullErrorMessage(response);
            AssertEmptyCollection(nameof(response.Infos), response.Infos);
        }

        [TestMethod]
        public void TestIncorrectAsset2()
        {
            var asset2 = Features.UnexistingAsset;
            var response = Manager.Exchanges.Info.ExchangesSupportingPairs(Asset1, asset2);

            AssertNullErrorMessage(response);
            AssertEmptyCollection(nameof(response.Infos), response.Infos);
        }

        private Asset Asset1 { get; } = Features.Btc;
        private Asset Asset2 { get; } = Features.Eth;
    }
}