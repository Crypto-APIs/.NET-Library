using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Trades
{
    [TestClass]
    public class HistoricalTradesBySymbol : BaseCollectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol of null was inappropriately allowed.")]
        public void NullSymbol_Exception()
        {
            Symbol symbol = null;

            Manager.Exchanges.Trades.Historical(symbol);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol.Id of null was inappropriately allowed.")]
        public void NullSymbolId_Exception()
        {
            var symbol = new Symbol();

            Manager.Exchanges.Trades.Historical(symbol);
        }

        [TestMethod]
        public void UnexistingSymbol_ErrorMessage()
        {
            var symbol = Features.UnexistingSymbol;

            var response = Manager.Exchanges.Trades.Historical(symbol);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "Unknown symbol");
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Historical(Symbol);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Historical(Symbol, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Historical(Symbol, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.Historical(Symbol, skip, limit);
        }

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;

        private Symbol Symbol { get; } = Features.BtcLtc;
    }
}