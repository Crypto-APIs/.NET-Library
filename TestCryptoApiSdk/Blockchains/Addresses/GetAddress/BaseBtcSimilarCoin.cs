using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Blockchains.Addresses.GetAddress
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void InvalidAddress()
        {
            var response = Manager.Blockchains.Address.GetAddress<GetBtcAddressResponse>(NetworkCoin, address: "qwe");

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "Address is not valid");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress()
        {
            Manager.Blockchains.Address.GetAddress<GetBtcAddressResponse>(NetworkCoin, address: null);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}