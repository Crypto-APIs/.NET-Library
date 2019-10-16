using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Exchanges.Rates
{
    [Ignore] // todo: note #3
    [TestClass]
    public class ExchangeRatesInExchange : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, Exchange);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, Exchange, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, Exchange, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, Exchange, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset of null was inappropriately allowed.")]
        public void TestNullAsset()
        {
            Asset baseAsset = null;
            Manager.Exchanges.Rates.GetAny(baseAsset, Exchange);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset.Id of null was inappropriately allowed.")]
        public void TestNullAssetId()
        {
            var baseAsset = new Asset();
            Manager.Exchanges.Rates.GetAny(baseAsset, Exchange);
        }

        [TestMethod]
        public void TestIncorrectBaseAsset()
        {
            var baseAsset = Features.UnexistingAsset;
            var timeStamp = new DateTime(2019, 02, 03);
            var response = Manager.Exchanges.Rates.GetAny(baseAsset, Exchange, timeStamp);

            AssertErrorMessage(response, "Asset not found");
            AssertEmptyCollection(nameof(response.Rates), response.Rates);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void TestNullExchange()
        {
            Exchange exchange = null;
            Manager.Exchanges.Rates.GetAny(BaseAsset, exchange);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void TestNullExchangeId()
        {
            var exchange = new Exchange();
            Manager.Exchanges.Rates.GetAny(BaseAsset, exchange);
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var exchange = Features.UnexistingExchange;
            var response = Manager.Exchanges.Rates.GetAny(BaseAsset, exchange);

            AssertErrorMessage(response, "Asset not found");
            AssertEmptyCollection(nameof(response.Rates), response.Rates);
        }

        private Asset BaseAsset { get; } = Features.Btc;
        private Exchange Exchange { get; } = Features.Bittrex;
    }
}