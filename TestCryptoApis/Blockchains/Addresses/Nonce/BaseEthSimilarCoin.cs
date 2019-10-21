using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.Nonce
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Address.GetNonce<EthGetNonceResponse>(
                NetworkCoin, Address);

            AssertNullErrorMessage(response);
            Assert.IsTrue(response.Payload.Nonce >= 0,
                $"'{nameof(response.Payload.Nonce)}' must not be greater than 0");
        }

        [TestMethod]
        public void WrongAddress()
        {
            var address = "qw'e";
            var response = Manager.Blockchains.Address.GetNonce<EthGetNonceResponse>(
                NetworkCoin, address);

            AssertErrorMessage(response, $"0x{address} is not a valid Ethereum address");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress()
        {
            string address = null;
            Manager.Blockchains.Address.GetNonce<EthGetNonceResponse>(NetworkCoin, address);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string Address { get; }
    }
}