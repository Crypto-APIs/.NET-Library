using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.DataTypes.Exceptions;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Linq;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class GetLatestSymbolTrades : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.GetLatestTrades(Symbol);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.GetLatestTrades(Symbol, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.GetLatestTrades(Symbol, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            Debug.Assert(Skip.HasValue);
            Debug.Assert(Limit.HasValue);
            return Manager.Exchanges.GetLatestTrades(Symbol, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(RequestException), "A Symbol of null was inappropriately allowed.")]
        public void TestUndefinedSymbol()
        {
            Manager.Exchanges.GetLatestTrades(symbol: null);
        }

        [TestMethod]
        public void TestIncorrectSymbol()
        {
            var symbol = new Symbol("QWEEWQ1");

            var response = Manager.Exchanges.GetLatestTrades(symbol);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Unknown symbol", response.ErrorMessage);
            Assert.IsNotNull(response.Trades);
            Assert.IsFalse(response.Trades.Any());
        }

        private Symbol Symbol { get; } = new Symbol("5b7add17b2fc9a000157cc0a");
    }
}