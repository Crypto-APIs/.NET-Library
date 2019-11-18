using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CryptoApisLibrary.Tests.TestDataProviders;

namespace CryptoApisLibrary.Tests.Blockchains.Addresses.GetAddress
{
    [TestClass]
    public class BtcSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void InvalidAddress_ErrorMessage(NetworkCoin networkCoin)
        {
            var address = "qw'e";

            var response = Manager.Blockchains.Address.GetAddress<GetBtcAddressResponse>(networkCoin, address);

            AssertErrorMessage(response, "Address is not valid");
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress_Exception(NetworkCoin networkCoin)
        {
            string address = null;

            Manager.Blockchains.Address.GetAddress<GetBtcAddressResponse>(networkCoin, address);
        }

    }
}