using System;
using System.Diagnostics;
using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Exchanges.Trades
{
    [Ignore] // todo: check IsPerhapsNotAnExactMatch flag
    [TestClass]
    public class LatestSymbolTrades : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Latest(Symbol);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Latest(Symbol, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Latest(Symbol, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.Latest(Symbol, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol of null was inappropriately allowed.")]
        public void TestNullSymbol()
        {
            Symbol symbol = null;
            Manager.Exchanges.Trades.Latest(symbol);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol.Id of null was inappropriately allowed.")]
        public void TestNullSymbolId()
        {
            var symbol = new Symbol();
            Manager.Exchanges.Trades.Latest(symbol);
        }

        [TestMethod]
        public void TestIncorrectSymbol()
        {
            var symbol = Features.UnexistingSymbol;
            var response = Manager.Exchanges.Trades.Latest(symbol);

            AssertErrorMessage(response, "Unknown symbol");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

        private Symbol Symbol { get; } = Features.BtcLtc;
    }
}