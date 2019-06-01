using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.Tokens.GetBalance
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public virtual void GeneralTest()
        {
            var response = Manager.Blockchains.Token.GetBalance(Coin, Network, Address, Contract);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Symbol));
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Name));
        }

        [TestMethod]
        public void InvalidAddress()
        {
            var address = "1'23";
            var response = Manager.Blockchains.Token.GetBalance(Coin, Network, address, Contract);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Invalid address or contract", response.ErrorMessage);
        }

        [TestMethod]
        public void InvalidContract()
        {
            var contract = "1'23";
            var response = Manager.Blockchains.Token.GetBalance(Coin, Network, Address, contract);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Invalid address or contract", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress()
        {
            string address = null;
            Manager.Blockchains.Token.GetBalance(Coin, Network, address, Contract);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Contract of null was inappropriately allowed.")]
        public void NullContract()
        {
            string contract = null;
            Manager.Blockchains.Token.GetBalance(Coin, Network, Address, contract);
        }

        protected abstract EthSimilarCoin Coin { get; }
        protected abstract EthSimilarNetwork Network { get; }
        protected abstract string Address { get; }
        protected abstract string Contract { get; }
    }
}