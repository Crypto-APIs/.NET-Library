using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Blockchains.Addresses.GetAddress
{
    [TestClass]
    public class EthSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void InvalidAddress_ErrorMessage(NetworkCoin networkCoin)
        {
            var address = "qw'e";

            var response = Manager.Blockchains.Address.GetAddress<GetEthAddressResponse>(networkCoin, address);

            AssertErrorMessage(response, $"0x{address}  is not a valid Ethereum address");
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress_Exception(NetworkCoin networkCoin)
        {
            string address = null;

            Manager.Blockchains.Address.GetAddress<GetEthAddressResponse>(networkCoin, address);
        }
    }
}