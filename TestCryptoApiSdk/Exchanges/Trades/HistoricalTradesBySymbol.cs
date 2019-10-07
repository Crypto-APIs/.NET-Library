using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdk.Exchanges.Trades
{
    [TestClass]
    public class HistoricalTradesBySymbol : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Historical(Symbol);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Historical(Symbol, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Historical(Symbol, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.Historical(Symbol, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol of null was inappropriately allowed.")]
        public void TestNullSymbol()
        {
            Manager.Exchanges.Trades.Historical(symbol: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol.Id of null was inappropriately allowed.")]
        public void TestNullSymbolId()
        {
            Manager.Exchanges.Trades.Historical(new Symbol());
        }

        [TestMethod]
        public void TestIncorrectSymbol()
        {
            var symbol = new Symbol("QWE'EWQ1");
            var response = Manager.Exchanges.Trades.Historical(symbol);

            AssertNotNullResponse(response);
            if (IsAdditionalPackagePlan)
            {
                AssertErrorMessage(response, "Unknown symbol");
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
            else
            {
                AssertErrorMessage(response, "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
            }
        }

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;
//        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Symbol Symbol { get; } = new Symbol("5b7add17b2fc9a000157cc0a");
    }
}