using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class ExchangeRates : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.ExchangeRates(BaseAsset);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.ExchangeRates(BaseAsset, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.ExchangeRates(BaseAsset, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.ExchangeRates(BaseAsset, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Asset of null was inappropriately allowed.")]
        public void TestNull()
        {
            Manager.Exchanges.ExchangeRates(baseAsset: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Asset.Id of null was inappropriately allowed.")]
        public void TestNullId()
        {
            Manager.Exchanges.ExchangeRates(new Asset());
        }

        private Asset BaseAsset { get; } = new Asset("5b1ea92e584bf50020130615");
        protected override bool IsPerhapsNotAnExactMatch { get; } = true;
    }
}