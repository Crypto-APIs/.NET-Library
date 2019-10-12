using System;
using System.Diagnostics;
using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Exchanges.Trades
{
    [TestClass]
    public class LatestSymbolTrades : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Latest(Symbol);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Latest(Symbol, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Latest(Symbol, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            Debug.Assert(Skip.HasValue);
            Debug.Assert(Limit.HasValue);
            return Manager.Exchanges.Trades.Latest(Symbol, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol of null was inappropriately allowed.")]
        public void TestNullSymbol()
        {
            Manager.Exchanges.Trades.Latest(symbol: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol.Id of null was inappropriately allowed.")]
        public void TestNullSymbolId()
        {
            Manager.Exchanges.Trades.Latest(new Symbol());
        }

        [TestMethod]
        public void TestIncorrectSymbol()
        {
            var symbol = new Symbol("QWE'EWQ1");
            var response = Manager.Exchanges.Trades.Latest(symbol);

            AssertErrorMessage(response, "Unknown symbol");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        private Symbol Symbol { get; } = new Symbol("5b7add17b2fc9a000157cc0a");
    }
}