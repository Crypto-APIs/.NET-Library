using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdk.Exchanges.Rates
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
            return Manager.Exchanges.Rates.GetAny(BaseAsset, skip: skip);
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
        [ExpectedException(typeof(ArgumentNullException), "A Asset of null was inappropriately allowed.")]
        public void TestNull()
        {
            Manager.Exchanges.Rates.GetAny(baseAsset: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Asset.Id of null was inappropriately allowed.")]
        public void TestNullId()
        {
            Manager.Exchanges.Rates.GetAny(new Asset());
        }

        [TestMethod]
        public void TestUndefineAsset()
        {
            var baseAsset = new Asset("QWEW'WQ");
            var response = Manager.Exchanges.Rates.GetAny(baseAsset);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "Asset not found");
            AssertEmptyCollection(nameof(response.Rates), response.Rates);
        }

        private Asset BaseAsset { get; } = new Asset("5b1ea92e584bf50020130615");
        protected override bool IsPerhapsNotAnExactMatch { get; } = true;
    }
}