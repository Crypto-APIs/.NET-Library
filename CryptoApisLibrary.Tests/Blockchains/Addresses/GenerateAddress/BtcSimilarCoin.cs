using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CryptoApisLibrary.Tests.Blockchains.Addresses.GenerateAddress
{
    [TestClass]
    public class BtcSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestDataExceptBch))]
        public void ExceptBch_AllCorrect_ShouldPass(NetworkCoin networkCoin)
        {
            var address = Manager.Blockchains.Address.GenerateAddress<GenerateBtcAddressResponse>(networkCoin)?.Payload?.Address;

            var getAddressResponse = Manager.Blockchains.Address.GetAddress<GetBtcAddressResponse>(networkCoin, address);

            AssertNullErrorMessage(getAddressResponse);
            Assert.IsFalse(string.IsNullOrEmpty(getAddressResponse.Payload.Address),
                $"'{nameof(getAddressResponse.Payload.Address)}' must not be null");
            Assert.AreEqual(address, getAddressResponse.Payload.Address, "'Address' is wrong");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestDataBch))]
        public void Bch_AllCorrect_ShouldPass(NetworkCoin networkCoin)
        {
            var address = Manager.Blockchains.Address.GenerateAddress<GenerateBchAddressResponse>(networkCoin)?.Payload?.Bch;

            var getAddressResponse = Manager.Blockchains.Address.GetAddress<GetBtcAddressResponse>(networkCoin, address);

            AssertNullErrorMessage(getAddressResponse);
            Assert.IsFalse(string.IsNullOrEmpty(getAddressResponse.Payload.Address),
                $"'{nameof(getAddressResponse.Payload.Address)}' must not be null");
            Assert.AreEqual(address, getAddressResponse.Payload.Address, "'Address' is wrong");
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress_Exception(NetworkCoin networkCoin)
        {
            string address = null;

            Manager.Blockchains.Address.GetAddress<GetBtcAddressResponse>(networkCoin, address);
        }

        private static IEnumerable<object[]> GetTestDataExceptBch
        {
            get
            {
                yield return new object[] { NetworkCoin.BtcMainNet };
                yield return new object[] { NetworkCoin.BtcTestNet };
                yield return new object[] { NetworkCoin.DashMainNet };
                yield return new object[] { NetworkCoin.DashTestNet };
                yield return new object[] { NetworkCoin.DogeMainNet };
                yield return new object[] { NetworkCoin.DogeTestNet };
                yield return new object[] { NetworkCoin.LtcMainNet };
                yield return new object[] { NetworkCoin.LtcTestNet };
            }
        }

        private static IEnumerable<object[]> GetTestDataBch
        {
            get
            {
                yield return new object[] { NetworkCoin.BchMainNet };
                yield return new object[] { NetworkCoin.BchTestNet };
            }
        }
    }
}