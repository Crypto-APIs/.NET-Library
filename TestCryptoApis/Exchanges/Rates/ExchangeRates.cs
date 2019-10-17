using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Exchanges.Rates
{
    [TestClass]
    public class ExchangeRates : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset of null was inappropriately allowed.")]
        public void TestNull()
        {
            Asset baseAsset = null;
            Manager.Exchanges.Rates.GetAny(baseAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset.Id of null was inappropriately allowed.")]
        public void TestNullId()
        {
            var baseAsset = new Asset();
            Manager.Exchanges.Rates.GetAny(baseAsset);
        }

        [TestMethod]
        public void TestUndefineAsset()
        {
            var baseAsset = Features.UnexistingAsset;
            var response = Manager.Exchanges.Rates.GetAny(baseAsset);

            AssertErrorMessage(response, "Asset not found");
            AssertEmptyCollection(nameof(response.Rates), response.Rates);
        }

        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Asset BaseAsset { get; } = Features.Ltc;
    }
}