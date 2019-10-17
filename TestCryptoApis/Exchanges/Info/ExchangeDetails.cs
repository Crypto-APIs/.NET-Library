using System;
using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Exchanges.Info
{
    [TestClass]
    public class ExchangeDetails : BaseTest
    {
        [TestMethod]
        public void TestCorrect()
        {
            var exchange = Features.Bittrex;
            var response = Manager.Exchanges.Info.ExchangeDetails(exchange);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Exchange, $"'{nameof(response.Exchange)}' must not be null");
            Assert.AreEqual("Bittrex", response.Exchange.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void TestNull()
        {
            Exchange exchange = null;
            Manager.Exchanges.Info.ExchangeDetails(exchange);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void TestNullId()
        {
            var exchange = new Exchange();
            Manager.Exchanges.Info.ExchangeDetails(exchange);
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var exchange = Features.UnexistingExchange;
            var response = Manager.Exchanges.Info.ExchangeDetails(exchange);

            AssertErrorMessage(response, "Exchange not found");
            Assert.IsNull(response.Exchange, $"'{nameof(response.Exchange)}' must be null");
        }
    }
}