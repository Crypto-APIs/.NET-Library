using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdk.Exchanges.Trades
{
    [TestClass]
    public class HistoricalTradesByExchange : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Historical(Exchange);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Historical(Exchange, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Historical(Exchange, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.Historical(Exchange, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void TestNullExchange()
        {
            Manager.Exchanges.Trades.Historical(exchange: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void TestNullExchangeId()
        {
            Manager.Exchanges.Trades.Historical(new Exchange());
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var exchange = new Exchange("QWE'EWQ1");
            var response = Manager.Exchanges.Trades.Historical(exchange);

            AssertNotNullResponse(response);
            if (IsAdditionalPackagePlan)
            {
                AssertErrorMessage(response, "We are facing technical issues, please try again later");
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
            else
            {
                AssertErrorMessage(response, "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
            }
        }

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;
        //protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Exchange Exchange { get; } = new Exchange("5b1ea9d21090c200146f7362");
    }
}