using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CryptoApisLibrary.Tests.Blockchains.Addresses.Nonce
{
    [TestClass]
    public class EthSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin, string address)
        {
            var response = Manager.Blockchains.Address.GetNonce<EthGetNonceResponse>(
                networkCoin, address);

            AssertNullErrorMessage(response);
            Assert.IsTrue(response.Payload.Nonce >= 0,
                $"'{nameof(response.Payload.Nonce)}' must not be greater than 0");
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void InvalidAddress_ErrorMessage(NetworkCoin networkCoin)
        {
            var address = "qw'e";

            var response = Manager.Blockchains.Address.GetNonce<EthGetNonceResponse>(
                networkCoin, address);

            AssertErrorMessage(response, $"0x{address} is not a valid Ethereum address");
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress_Exception(NetworkCoin networkCoin)
        {
            string address = null;

            Manager.Blockchains.Address.GetNonce<EthGetNonceResponse>(networkCoin, address);
        }

        private static IEnumerable<object[]> GetTestData
        {
            get
            {
                yield return new object[] { NetworkCoin.EthMainNet, Features.CorrectAddress.EthMainNet };
                yield return new object[] { NetworkCoin.EthRinkeby, Features.CorrectAddress.EthRinkenby };
                yield return new object[] { NetworkCoin.EthRopsten, Features.CorrectAddress.EthRopsten };
                yield return new object[] { NetworkCoin.EtcMainNet, Features.CorrectAddress.EtcMainNet };
                yield return new object[] { NetworkCoin.EtcMorden, Features.CorrectAddress.EtcMorden };
            }
        }
    }
}