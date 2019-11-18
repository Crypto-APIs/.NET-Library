using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Rates
{
    [TestClass]
    public class ExchangeRates : BaseCollectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset of null was inappropriately allowed.")]
        public void NullAsset_Exception()
        {
            Asset baseAsset = null;

            Manager.Exchanges.Rates.GetAny(baseAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset.Id of null was inappropriately allowed.")]
        public void NullAssetId_Exception()
        {
            var baseAsset = new Asset();

            Manager.Exchanges.Rates.GetAny(baseAsset);
        }

        [TestMethod]
        public void UnexistingAsset_ErrorMessage()
        {
            var baseAsset = Features.UnexistingAsset;

            var response = Manager.Exchanges.Rates.GetAny(baseAsset);

            AssertErrorMessage(response, "Asset not found");
            AssertEmptyCollection(nameof(response.Rates), response.Rates);
        }

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

        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Asset BaseAsset { get; } = Features.Ltc;
    }
}