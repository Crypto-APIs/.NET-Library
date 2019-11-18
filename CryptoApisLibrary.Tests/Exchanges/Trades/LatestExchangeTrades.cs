using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Trades
{
    [TestClass]
    public class LatestExchangeTrades : BaseCollectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Exchange of null was inappropriately allowed.")]
        public void NullExchange_Exception()
        {
            Exchange exchange = null;

            Manager.Exchanges.Trades.Latest(exchange);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Exchange.Id of null was inappropriately allowed.")]
        public void NullExchangeId_Exception()
        {
            var exchange = new Exchange();

            Manager.Exchanges.Trades.Latest(exchange);
        }

        [TestMethod]
        public void UnexistingExchange_ErrorMessage()
        {
            var exchange = Features.UnexistingExchange;

            var response = Manager.Exchanges.Trades.Latest(exchange);

            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        [Ignore] //todo: random sequence of collection elements with equality "EventTime"
        [TestMethod]
        public override void MainTest()
        { }

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

        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Exchange Exchange { get; } = Features.Bittrex;
    }
}