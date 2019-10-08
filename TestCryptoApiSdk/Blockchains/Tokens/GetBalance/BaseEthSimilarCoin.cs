using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Blockchains.Tokens.GetBalance
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public virtual void GeneralTest()
        {
            var response = Manager.Blockchains.Token.GetBalance<GetBalanceTokenResponse>(NetworkCoin, Address, Contract);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Symbol), 
                $"'{nameof(response.Payload.Symbol)}' must not be null");
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Name), 
                $"'{nameof(response.Payload.Name)}' must not be null");
        }

        [TestMethod]
        public void InvalidAddress()
        {
            var address = "1'23";
            var response = Manager.Blockchains.Token.GetBalance<GetBalanceTokenResponse>(NetworkCoin, address, Contract);

            AssertErrorMessage(response, "Invalid address or contract");
        }

        [TestMethod]
        public void InvalidContract()
        {
            var contract = "1'23";
            var response = Manager.Blockchains.Token.GetBalance<GetBalanceTokenResponse>(NetworkCoin, Address, contract);

            AssertErrorMessage(response, "Invalid address or contract");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress()
        {
            string address = null;
            Manager.Blockchains.Token.GetBalance<GetBalanceTokenResponse>(NetworkCoin, address, Contract);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Contract of null was inappropriately allowed.")]
        public void NullContract()
        {
            string contract = null;
            Manager.Blockchains.Token.GetBalance<GetBalanceTokenResponse>(NetworkCoin, Address, contract);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string Address { get; }
        protected abstract string Contract { get; }
    }
}