using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Info
{
    [TestClass]
    public class ExchangeDetails : BaseTest
    {
        [TestMethod]
        public void AllCorrect_ShouldPass()
        {
            var exchange = Features.Bittrex;

            var response = Manager.Exchanges.Info.ExchangeDetails(exchange);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Exchange, $"'{nameof(response.Exchange)}' must not be null");
            Assert.AreEqual("Bittrex", response.Exchange.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void NullExchange_Exception()
        {
            Exchange exchange = null;

            Manager.Exchanges.Info.ExchangeDetails(exchange);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void NullExchangeId_Exception()
        {
            var exchange = new Exchange();

            Manager.Exchanges.Info.ExchangeDetails(exchange);
        }

        [TestMethod]
        public void UnexistingExchange_ErrorMessage()
        {
            var exchange = Features.UnexistingExchange;

            var response = Manager.Exchanges.Info.ExchangeDetails(exchange);

            AssertErrorMessage(response, "Exchange not found");
            Assert.IsNull(response.Exchange, $"'{nameof(response.Exchange)}' must be null");
        }
    }
}