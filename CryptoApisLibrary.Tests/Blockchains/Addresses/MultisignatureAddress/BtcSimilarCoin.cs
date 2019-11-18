using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Blockchains.Addresses.MultisignatureAddress
{
    [TestClass]
    public class BtcSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void InvalidAddress_ErrorMessage(NetworkCoin networkCoin)
        {
            var address = "qw'e";

            var response = Manager.Blockchains.Address.GetAddressInMultisignatureAddresses<GetBtcMultisignatureAddressesResponse>(
                networkCoin, address);

            AssertErrorMessage(response, "Internal Server Error");
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress_Exception(NetworkCoin networkCoin)
        {
            string address = null;

            Manager.Blockchains.Address.GetAddressInMultisignatureAddresses<GetBtcMultisignatureAddressesResponse>(
                networkCoin, address);
        }
    }
}