using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.DataTypes.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class ExchangeDetails : BaseTest
    {
        [TestMethod]
        public void TestCorrect()
        {
            var exchange = new Exchange("5b1ea9d21090c200146f7366");
            var response = Manager.Exchanges.ExchangeDetails(exchange);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Exchange);
            Assert.AreEqual("Bittrex", response.Exchange.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void TestNull()
        {
            Manager.Exchanges.ExchangeDetails(exchange: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void TestNullId()
        {
            Manager.Exchanges.ExchangeDetails(new Exchange());
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var exchange = new Exchange("QWE'EWQ");
            var response = Manager.Exchanges.ExchangeDetails(exchange);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Entity not found", response.ErrorMessage);
            Assert.IsNull(response.Exchange);
        }

        
    }
}