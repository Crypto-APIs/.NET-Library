using System;
using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Exchanges.Info
{
    [TestClass]
    public class ExchangeDetails : BaseTest
    {
        [TestMethod]
        public void TestCorrect()
        {
            var exchange = new Exchange("5b1ea9d21090c200146f7366");
            var response = Manager.Exchanges.Info.ExchangeDetails(exchange);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Exchange, $"'{nameof(response.Exchange)}' must not be null");
            Assert.AreEqual("Bittrex", response.Exchange.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void TestNull()
        {
            Manager.Exchanges.Info.ExchangeDetails(exchange: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void TestNullId()
        {
            Manager.Exchanges.Info.ExchangeDetails(new Exchange());
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var exchange = new Exchange("QWE'EWQ");
            var response = Manager.Exchanges.Info.ExchangeDetails(exchange);

            AssertErrorMessage(response, "Entity not found");
            Assert.IsNull(response.Exchange, $"'{nameof(response.Exchange)}' must be null");
        }
    }
}