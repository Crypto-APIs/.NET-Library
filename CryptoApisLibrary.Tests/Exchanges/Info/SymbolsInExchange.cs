using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Exchanges.Info
{
    [TestClass]
    public class SymbolsInExchange : BaseCollectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Exchange of null was inappropriately allowed.")]
        public void NullExchange_Exception()
        {
            Exchange exchange = null;

            Manager.Exchanges.Info.SymbolsInExchange(exchange);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Exchange.Id of null was inappropriately allowed.")]
        public void NullExchangeId_Exception()
        {
            var exchange = new Exchange();

            Manager.Exchanges.Info.SymbolsInExchange(exchange);
        }

        [TestMethod]
        public void UnexistingExchange_EmptyResultCollection()
        {
            var exchange = Features.UnexistingExchange;

            var response = Manager.Exchanges.Info.SymbolsInExchange(exchange);

            AssertNullErrorMessage(response);
            AssertEmptyCollection(nameof(response.Infos), response.Infos);
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Info.SymbolsInExchange(Exchange);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Info.SymbolsInExchange(Exchange, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Info.SymbolsInExchange(Exchange, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Info.SymbolsInExchange(Exchange, skip, limit);
        }

        private Exchange Exchange { get; } = Features.Bittrex;
    }
}