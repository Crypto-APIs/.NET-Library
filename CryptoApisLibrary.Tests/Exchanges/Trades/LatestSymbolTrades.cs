using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Trades
{
    [TestClass]
    public class LatestSymbolTrades : BaseCollectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol of null was inappropriately allowed.")]
        public void NullSymbol_Exception()
        {
            Symbol symbol = null;

            Manager.Exchanges.Trades.Latest(symbol);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol.Id of null was inappropriately allowed.")]
        public void NullSymbolId_Exception()
        {
            var symbol = new Symbol();

            Manager.Exchanges.Trades.Latest(symbol);
        }

        [TestMethod]
        public void UnexistingSymbol_ErrorMessage()
        {
            var symbol = Features.UnexistingSymbol;

            var response = Manager.Exchanges.Trades.Latest(symbol);

            AssertErrorMessage(response, "Unknown symbol");
            AssertEmptyCollection(nameof(response.Trades), response.Trades);
        }

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

        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Symbol Symbol { get; } = Features.BtcLtc;
    }
}