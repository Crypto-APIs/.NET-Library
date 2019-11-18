using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Blockchains.Addresses.GenerateAddress
{
    [TestClass]
    public class EthSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin)
        {
            var address = Manager.Blockchains.Address.GenerateAddress<GenerateEthAddressResponse>(networkCoin)?.Payload?.Address;

            var getAddressResponse = Manager.Blockchains.Address.GetAddress<GetEthAddressResponse>(networkCoin, address);

            AssertNullErrorMessage(getAddressResponse);
            Assert.IsFalse(string.IsNullOrEmpty(getAddressResponse.Payload.Address),
                $"'{nameof(getAddressResponse.Payload.Address)}' must not be null");
            Assert.AreEqual(address, getAddressResponse.Payload.Address, "'Address' is wrong");
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