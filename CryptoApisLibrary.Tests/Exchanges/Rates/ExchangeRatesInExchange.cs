using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Rates
{
    [TestClass]
    public class ExchangeRatesInExchange : BaseCollectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset of null was inappropriately allowed.")]
        public void NullAsset_Exception()
        {
            Asset baseAsset = null;
            var exchange = Features.Bittrex;

            Manager.Exchanges.Rates.GetAny(baseAsset, exchange);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset.Id of null was inappropriately allowed.")]
        public void NullAssetId_Exception()
        {
            var baseAsset = new Asset();
            var exchange = Features.Bittrex;

            Manager.Exchanges.Rates.GetAny(baseAsset, exchange);
        }

        [TestMethod]
        public void UnexistingBaseAsset_ErrorMessage()
        {
            var baseAsset = Features.UnexistingAsset;
            var exchange = Features.Bittrex;

            var response = Manager.Exchanges.Rates.GetAny(baseAsset, exchange);

            AssertErrorMessage(response, "Asset not found");
            AssertEmptyCollection(nameof(response.Rates), response.Rates);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void NullExchange_Exception()
        {
            var baseAsset = Features.Btc;
            Exchange exchange = null;

            Manager.Exchanges.Rates.GetAny(baseAsset, exchange);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void NullExchangeId_Exception()
        {
            var baseAsset = Features.Btc;
            var exchange = new Exchange();

            Manager.Exchanges.Rates.GetAny(baseAsset, exchange);
        }

        [TestMethod]
        public void UnexistingExchange_ErrorMessage()
        {
            var baseAsset = Features.Btc;
            var exchange = Features.UnexistingExchange;

            var response = Manager.Exchanges.Rates.GetAny(baseAsset, exchange);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Rates), response.Rates);
        }

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

        private Asset BaseAsset { get; } = Features.Btc;
        private Exchange Exchange { get; } = Features.Bittrex;
    }
}