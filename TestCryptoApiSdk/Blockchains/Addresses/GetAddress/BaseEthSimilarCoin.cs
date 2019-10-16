using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Blockchains.Addresses.GetAddress
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void InvalidAddress()
        {
            var address = "qw'e";
            var response = Manager.Blockchains.Address.GetAddress<GetEthAddressResponse>(NetworkCoin, address);

            AssertErrorMessage(response, $"0x{address}  is not a valid Ethereum address");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress()
        {
            string address = null;
            Manager.Blockchains.Address.GetAddress<GetEthAddressResponse>(NetworkCoin, address);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}