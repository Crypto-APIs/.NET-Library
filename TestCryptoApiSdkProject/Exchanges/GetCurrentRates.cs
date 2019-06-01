using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.DataTypes.Exceptions;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class GetCurrentRates : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.GetCurrentRates(BaseAsset, TimeStamp);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.GetCurrentRates(BaseAsset, TimeStamp, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.GetCurrentRates(BaseAsset, TimeStamp, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.GetCurrentRates(BaseAsset, TimeStamp, skip, limit);
        }

        /// <remarks>
        /// Sometimes it doesn't. The reason is unclear.
        /// </remarks>
        [TestMethod]
        public void TestSimple()
        {
            var baseAsset = new Asset("USD");
            var response = Manager.Exchanges.GetCurrentRates(baseAsset);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));

            Assert.AreEqual(0, response.Meta.Index);
            Assert.AreEqual(50, response.Meta.Limit);

            var testingRates = response.Rates;
            Assert.IsNotNull(testingRates);
            Assert.IsTrue(testingRates.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(RequestException), "A BaseAsset of null was inappropriately allowed.")]
        public void TestNullAsset()
        {
            var timeStamp = new DateTime(2019, 02, 03);
            Manager.Exchanges.GetCurrentRates(baseAsset: null, timeStamp: timeStamp);
        }

        [TestMethod]
        public void TestUndefineAsset()
        {
            var baseAsset = new Asset("QWEWWQ");
            var response = Manager.Exchanges.GetCurrentRates(baseAsset);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Asset not found", response.ErrorMessage);
            Assert.IsNotNull(response.Rates);
            Assert.IsFalse(response.Rates.Any());
        }

        [TestMethod]
        public void TestWrongTimestampFromFuture()
        {
            var timeStamp = new DateTime(DateTime.Now.Year + 1, 01, 01);
            var response = Manager.Exchanges.GetCurrentRates(BaseAsset, timeStamp);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Rates);
            Assert.IsFalse(response.Rates.Any());
        }

        [TestMethod]
        public void TestWrongTimestampFromPast()
        {
            var timeStamp = new DateTime(1960, 01, 01);
            var response = Manager.Exchanges.GetCurrentRates(BaseAsset, timeStamp);

            Assert.IsNotNull(response);
            Assert.AreEqual("Your package plan includes only 360 days historical data. Please contact us if you need more or upgrade your plan.", response.ErrorMessage);
            Assert.IsNotNull(response.Rates);
            Assert.IsFalse(response.Rates.Any());
        }

        private Asset BaseAsset { get; } = new Asset("USD");
        private DateTime TimeStamp { get; } = new DateTime(2019, 02, 03);
    }
}