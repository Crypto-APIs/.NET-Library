using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;

namespace TestCryptoApiSdk.Exchanges.Trades
{
    [TestClass]
    public class LatestExchangeTrades : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Latest(Exchange);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Latest(Exchange, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Latest(Exchange, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            Debug.Assert(Skip.HasValue);
            Debug.Assert(Limit.HasValue);
            return Manager.Exchanges.Trades.Latest(Exchange, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void TestNullExchange()
        {
            Manager.Exchanges.Trades.Latest(exchange: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void TestNullExchangeId()
        {
            Manager.Exchanges.Trades.Latest(new Exchange());
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var exchange = new Exchange("QWE'EWQ1");

            var response = Manager.Exchanges.Trades.Latest(exchange);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "We are facing technical issues, please try again later");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        private Exchange Exchange { get; } = new Exchange("5b1ea9d21090c200146f7362");
    }
}