using System;
using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Exchanges.Trades
{
    [Ignore] // todo: похоже, нужен IsPerhapsNotAnExactMatch. Проанализировать Fiddler'ом запросы
    [TestClass]
    public class HistoricalTradesBySymbol : BaseCollectionTest
    {
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol of null was inappropriately allowed.")]
        public void TestNullSymbol()
        {
            Symbol symbol = null;
            Manager.Exchanges.Trades.Historical(symbol);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol.Id of null was inappropriately allowed.")]
        public void TestNullSymbolId()
        {
            var symbol = new Symbol();
            Manager.Exchanges.Trades.Historical(symbol);
        }

        [TestMethod]
        public void TestIncorrectSymbol()
        {
            var symbol = Features.UnexistingSymbol;
            var response = Manager.Exchanges.Trades.Historical(symbol);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "Unknown symbol");
                AssertEmptyCollection(nameof(response.Trades), response.Trades);
            }
        }

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;
        //        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Symbol Symbol { get; } = Features.BtcLtc;
    }
}