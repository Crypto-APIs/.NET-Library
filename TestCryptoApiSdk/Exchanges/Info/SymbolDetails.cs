using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Exchanges.Info
{
    [TestClass]
    public class SymbolDetails : BaseTest
    {
        [TestMethod]
        public void TestCorrect()
        {
            var symbol = new Symbol("5bfc325c9c40a100014db8ff");
            var response = Manager.Exchanges.Info.SymbolDetails(symbol);

            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Symbol, "Response.Symbol must not be null");
            Assert.AreEqual("etheur", response.Symbol.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol of null was inappropriately allowed.")]
        public void TestNull()
        {
            Manager.Exchanges.Info.SymbolDetails(symbol: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol.Id of null was inappropriately allowed.")]
        public void TestNullId()
        {
            Manager.Exchanges.Info.SymbolDetails(new Symbol());
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var symbol = new Symbol("QWE'EWQ");
            var response = Manager.Exchanges.Info.SymbolDetails(symbol);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "Entity not found");
            Assert.IsNull(response.Symbol, "Response.Symbol must be null");
        }
    }
}