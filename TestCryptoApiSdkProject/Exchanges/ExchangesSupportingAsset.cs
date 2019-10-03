using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class ExchangesSupportingAsset : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.ExchangesSupportingAsset(Asset);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.ExchangesSupportingAsset(Asset, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.ExchangesSupportingAsset(Asset, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.ExchangesSupportingAsset(Asset, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset of null was inappropriately allowed.")]
        public void TestNullAsset()
        {
            Manager.Exchanges.ExchangesSupportingAsset(asset: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Asset.Id of null was inappropriately allowed.")]
        public void TestNullId()
        {
            Manager.Exchanges.ExchangesSupportingAsset(new Asset());
        }

        [TestMethod]
        public void TestIncorrectAsset()
        {
            var asset = new Asset("QWEEWQ1");

            var response = Manager.Exchanges.ExchangesSupportingAsset(asset);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Infos);
            Assert.IsFalse(response.Infos.Any());
        }

        private Asset Asset { get; } = new Asset("5b1ea92e584bf50020130612");
    }
}