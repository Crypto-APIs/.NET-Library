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
            var address = "qwe";
            var response = Manager.Blockchains.Address.GetAddress<GetEthAddressResponse>(NetworkCoin, address);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, $"0x{address}  is not a valid Ethereum address");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress()
        {
            Manager.Blockchains.Address.GetAddress<GetEthAddressResponse>(NetworkCoin, address: null);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}