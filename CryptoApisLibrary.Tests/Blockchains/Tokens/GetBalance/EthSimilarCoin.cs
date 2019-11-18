using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoApisLibrary.Tests.Blockchains.Tokens.GetBalance
{
    [TestClass]
    public class EthSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public virtual void AllCorrect_ShouldPass(NetworkCoin networkCoin, string address, string contract)
        {
            var response = Manager.Blockchains.Token.GetBalance<GetBalanceTokenResponse>(networkCoin, address, contract);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Symbol),
                $"'{nameof(response.Payload.Symbol)}' must not be null");
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Name),
                $"'{nameof(response.Payload.Name)}' must not be null");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestDataContract))]
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress_Exception(NetworkCoin networkCoin, string contract)
        {
            string address = null;

            Manager.Blockchains.Token.GetBalance<GetBalanceTokenResponse>(networkCoin, address, contract);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestDataContract))]
        public void InvalidAddress_ErrorMessage(NetworkCoin networkCoin, string contract)
        {
            var address = "1'23";

            var response = Manager.Blockchains.Token.GetBalance<GetBalanceTokenResponse>(networkCoin, address, contract);

            AssertErrorMessage(response, "Invalid address or contract");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestDataAddress))]
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Contract of null was inappropriately allowed.")]
        public void NullContract_Exception(NetworkCoin networkCoin, string address)
        {
            string contract = null;

            Manager.Blockchains.Token.GetBalance<GetBalanceTokenResponse>(networkCoin, address, contract);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestDataAddress))]
        [TestMethod]
        public void InvalidContract_ErrorMessage(NetworkCoin networkCoin, string address)
        {
            var contract = "1'23";

            var response = Manager.Blockchains.Token.GetBalance<GetBalanceTokenResponse>(networkCoin, address, contract);

            AssertErrorMessage(response, "Invalid address or contract");
        }

        private static IEnumerable<object[]> GetTestData => NetworkCoins.Select((networkCoin, i) => new object[] { networkCoin, Addresses[i], Contracts[i] });

        private static IEnumerable<object[]> GetTestDataContract => NetworkCoins.Select((networkCoin, i) => new object[] { networkCoin, Contracts[i] });

        private static IEnumerable<object[]> GetTestDataAddress => NetworkCoins.Select((networkCoin, i) => new object[] { networkCoin, Addresses[i] });

        private static readonly NetworkCoin[] NetworkCoins = {
            NetworkCoin.EthMainNet,
            NetworkCoin.EthRinkeby,
            NetworkCoin.EthRopsten,
            NetworkCoin.EtcMainNet,
            NetworkCoin.EtcMorden,
        };

        private static readonly string[] Addresses = {
            "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11",
            "0x7857af2143cb06ddc1dab5d7844c9402e89717cb",
            "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11",
            "0x737165b2913122aF76e05a3E6bbF2a6128484662",
            "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11",
        };

        private static readonly string[] Contracts = {
            "0xe7d553c3aab5943ec097d60535fd06f1b75db43e",
            "0x40f9405587B284f737Ef5c4c2ecEA1Fa8bfAE014",
            "0xe7d553c3aab5943ec097d60535fd06f1b75db43e",
            "0x1BE6D61B1103D91F7f86D47e6ca0429259A15ff0",
            "0xe7d553c3aab5943ec097d60535fd06f1b75db43e",
        };
    }
}