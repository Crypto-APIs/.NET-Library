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
            var address = "qw'e";
            var response = Manager.Blockchains.Address.GetAddress<GetBtcAddressResponse>(NetworkCoin, address);

            AssertErrorMessage(response, "Address is not valid");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress()
        {
            string address = null;
            Manager.Blockchains.Address.GetAddress<GetBtcAddressResponse>(NetworkCoin, address);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}