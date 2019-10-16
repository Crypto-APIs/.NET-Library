using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Exchanges.Trades
{
    [Ignore] // todo: check IsPerhapsNotAnExactMatch flag
    [TestClass]
    public class LatestExchangeTrades : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Latest(Exchange);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Latest(Exchange, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Latest(Exchange, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.Latest(Exchange, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Exchange of null was inappropriately allowed.")]
        public void TestNullExchange()
        {
            Exchange exchange = null;
            Manager.Exchanges.Trades.Latest(exchange);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Exchange.Id of null was inappropriately allowed.")]
        public void TestNullExchangeId()
        {
            var exchange = new Exchange();
            Manager.Exchanges.Trades.Latest(exchange);
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var exchange = Features.UnexistingExchange;
            var response = Manager.Exchanges.Trades.Latest(exchange);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        // protected override bool IsPerhapsNotAnExactMatch { get; } = true; 
        private Exchange Exchange { get; } = Features.Bittrex;
    }
}