using System;
using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Exchanges.Info
{
    [TestClass]
    public class SymbolDetails : BaseTest
    {
        [TestMethod]
        public void AllCorrect_ShouldPass()
        {
            var symbol = Features.BtcLtc;

            var response = Manager.Exchanges.Info.SymbolDetails(symbol);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Symbol, $"{nameof(response.Symbol)} must not be null");
            Assert.AreEqual("BTC-LTC", response.Symbol.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol of null was inappropriately allowed.")]
        public void NullSymbol_Exception()
        {
            Symbol symbol = null;

            Manager.Exchanges.Info.SymbolDetails(symbol);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol.Id of null was inappropriately allowed.")]
        public void NullSymbolId_Exception()
        {
            var symbol = new Symbol();

            Manager.Exchanges.Info.SymbolDetails(symbol);
        }

        [TestMethod]
        public void UnexistingSymbol_ErrorMessage()
        {
            var symbol = Features.UnexistingSymbol;

            var response = Manager.Exchanges.Info.SymbolDetails(symbol);

            AssertErrorMessage(response, "Entity not found");
            Assert.IsNull(response.Symbol, $"{nameof(response.Symbol)} must be null");
        }
    }
}