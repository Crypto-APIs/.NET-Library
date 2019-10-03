using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class SymbolsInExchange : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.SymbolsInExchange(Exchange);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.SymbolsInExchange(Exchange, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.SymbolsInExchange(Exchange, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.SymbolsInExchange(Exchange, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Exchange of null was inappropriately allowed.")]
        public void TestNullExchange()
        {
            Manager.Exchanges.SymbolsInExchange(exchange: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void TestNullId()
        {
            Manager.Exchanges.SymbolsInExchange(new Exchange());
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var exchange = new Exchange("QWEE'WQ1");

            var response = Manager.Exchanges.SymbolsInExchange(exchange);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Infos);
            Assert.IsFalse(response.Infos.Any());
        }

        private Exchange Exchange { get; } = new Exchange("5b1ea9d21090c200146f7366");
    }
}