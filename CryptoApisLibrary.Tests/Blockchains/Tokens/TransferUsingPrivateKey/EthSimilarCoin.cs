using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoApisLibrary.Tests.Blockchains.Tokens.TransferUsingPrivateKey
{
    [TestClass]
    public class EthSimilarCoin : BaseTest
    {
        [Ignore] // todo: no funds for full testing
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin, string fromAddress, string toAddress, string contract)
        {
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;
            var privateKey = "0xeb38783ad75d8081fb9105baee6ac9413c4abd732ef889116714f271cde6aed";

            var response = Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                networkCoin, fromAddress, toAddress, contract, gasPrice, gasLimit, amount, privateKey);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Hex),
                $"'{nameof(response.Payload.Hex)}' must not be null");
        }

        [Ignore] // todo: "insufficient funds for gas * price + value" for Ropsten
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void NotEnoughTokens_ErrorMessage(NetworkCoin networkCoin, string fromAddress, string toAddress, string contract)
        {
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;
            var privateKey = "0xeb38783ad75d8081fb9105baee6ac9413c4abd732ef889116714f271cde6aed";

            var response = Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                networkCoin, fromAddress, toAddress, contract, gasPrice, gasLimit, amount, privateKey);

            AssertErrorMessage(response, "Not enough tokens");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestDataCoinToAddressContract))]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress of null was inappropriately allowed.")]
        public void NullFromAddress_Exception(NetworkCoin networkCoin, string toAddress, string contract)
        {
            string fromAddress = null;
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;
            var privateKey = "0xeb38783ad75d8081fb9105baee6ac9413c4abd732ef889116714f271cde6aed";

            Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                networkCoin, fromAddress, toAddress, contract, gasPrice, gasLimit, amount, privateKey);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestDataCoinToAddressContract))]
        public void InvalidFromAddress_ErrorMessage(NetworkCoin networkCoin, string toAddress, string contract)
        {
            var fromAddress = "1'23";
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;
            var privateKey = "0xeb38783ad75d8081fb9105baee6ac9413c4abd732ef889116714f271cde6aed";

            var response = Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                networkCoin, fromAddress, toAddress, contract, gasPrice, gasLimit, amount, privateKey);

            AssertErrorMessage(response, $"fromAddress cannot be null or empty");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestDataCoinFromAddressContract))]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress of null was inappropriately allowed.")]
        public void NullToAddress_Exception(NetworkCoin networkCoin, string fromAddress, string contract)
        {
            string toAddress = null;
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;
            var privateKey = "0xeb38783ad75d8081fb9105baee6ac9413c4abd732ef889116714f271cde6aed";

            Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                networkCoin, fromAddress, toAddress, contract, gasPrice, gasLimit, amount, privateKey);
        }

        [Ignore]
        [DataTestMethod]
        [DynamicData(nameof(GetTestDataCoinFromAddressContract))]
        public void InvalidToAddress_ErrorMessage(NetworkCoin networkCoin, string fromAddress, string contract)
        {
            var toAddress = "1'23";
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;
            var privateKey = "0xeb38783ad75d8081fb9105baee6ac9413c4abd732ef889116714f271cde6aed";

            var response = Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                networkCoin, fromAddress, toAddress, contract, gasPrice, gasLimit, amount, privateKey);

            AssertErrorMessage(response, $"{toAddress}  is not a valid Ethereum address");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestDataCoinFromAddressToAddress))]
        [ExpectedException(typeof(ArgumentNullException), "A Contract of null was inappropriately allowed.")]
        public void NullContract_Exception(NetworkCoin networkCoin, string fromAddress, string toAddress)
        {
            string contract = null;
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;
            var privateKey = "0xeb38783ad75d8081fb9105baee6ac9413c4abd732ef889116714f271cde6aed";

            Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                networkCoin, fromAddress, toAddress, contract, gasPrice, gasLimit, amount, privateKey);
        }

        [Ignore]
        [DataTestMethod]
        [DynamicData(nameof(GetTestDataCoinFromAddressToAddress))]
        public void InvalidContract_ErrorMessage(NetworkCoin networkCoin, string fromAddress, string toAddress)
        {
            var contract = "1'23";
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;
            var privateKey = "0xeb38783ad75d8081fb9105baee6ac9413c4abd732ef889116714f271cde6aed";

            var response = Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                networkCoin, fromAddress, toAddress, contract, gasPrice, gasLimit, amount, privateKey);

            AssertErrorMessage(response, $"{contract}  is not a valid Ethereum address");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentNullException), "A Contract of null was inappropriately allowed.")]
        public void NullPrivateKey_Exception(NetworkCoin networkCoin, string fromAddress, string toAddress, string contract)
        {
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;
            string privateKey = null;

            Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                networkCoin, fromAddress, toAddress, contract, gasPrice, gasLimit, amount, privateKey);
        }

        [Ignore] //todo: "Internal Server Error" for Ropsten
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void InvalidPrivateKey_ErrorMessage(NetworkCoin networkCoin, string fromAddress, string toAddress, string contract)
        {
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;
            var privateKey = "1'23";

            var response = Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                networkCoin, fromAddress, toAddress, contract, gasPrice, gasLimit, amount, privateKey);

            AssertErrorMessage(response, "Not enough tokens");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A GasPrice was inappropriately allowed.")]
        public void InvalidGasPrice_Exception(NetworkCoin networkCoin, string fromAddress, string toAddress, string contract)
        {
            double gasPrice = 0;
            double gasLimit = 60000;
            double amount = 115;
            var privateKey = "0xeb38783ad75d8081fb9105baee6ac9413c4abd732ef889116714f271cde6aed";

            Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                networkCoin, fromAddress, toAddress, contract, gasPrice, gasLimit, amount, privateKey);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A GasLimit was inappropriately allowed.")]
        public void InvalidGasLimit_Exception(NetworkCoin networkCoin, string fromAddress, string toAddress, string contract)
        {
            double gasPrice = 11500000000;
            double gasLimit = 0;
            double amount = 115;
            var privateKey = "0xeb38783ad75d8081fb9105baee6ac9413c4abd732ef889116714f271cde6aed";

            Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                networkCoin, fromAddress, toAddress, contract, gasPrice, gasLimit, amount, privateKey);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An Amount was inappropriately allowed.")]
        public void InvalidAmount_Exception(NetworkCoin networkCoin, string fromAddress, string toAddress, string contract)
        {
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 0;
            var privateKey = "0xeb38783ad75d8081fb9105baee6ac9413c4abd732ef889116714f271cde6aed";

            Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                networkCoin, fromAddress, toAddress, contract, gasPrice, gasLimit, amount, privateKey);
        }

        private static IEnumerable<object[]> GetTestData =>
            NetworkCoins.Select((networkCoin, i) => new object[] { networkCoin, FromAddresses[i], ToAddresses[i], Contracts[i] });

        private static IEnumerable<object[]> GetTestDataCoinFromAddressContract =>
            NetworkCoins.Select((networkCoin, i) => new object[] { networkCoin, FromAddresses[i], Contracts[i] });

        private static IEnumerable<object[]> GetTestDataCoinToAddressContract =>
            NetworkCoins.Select((networkCoin, i) => new object[] { networkCoin, ToAddresses[i], Contracts[i] });

        private static IEnumerable<object[]> GetTestDataCoinFromAddressToAddress =>
            NetworkCoins.Select((networkCoin, i) => new object[] { networkCoin, FromAddresses[i], ToAddresses[i] });

        private static readonly NetworkCoin[] NetworkCoins = {
            NetworkCoin.EthMainNet,
            NetworkCoin.EthRinkeby,
            NetworkCoin.EthRopsten,
            NetworkCoin.EtcMainNet,
            NetworkCoin.EtcMorden,
        };

        private static readonly string[] FromAddresses = {
            "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11",
            "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11",
            "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11",
            "0xcbb36e2019f03c7d6dc8536b0d32e31aef18bded",
            "0xcbb36e2019f03c7d6dc8536b0d32e31aef18bded",
        };

        private static readonly string[] ToAddresses = {
            "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11",
            "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11",
            "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11",
            "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11",
            "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11",
        };

        private static readonly string[] Contracts = {
            "0xe7d553c3aab5943ec097d60535fd06f1b75db43e",
            "0xe7d553c3aab5943ec097d60535fd06f1b75db43e",
            "0xe7d553c3aab5943ec097d60535fd06f1b75db43e",
            "0x3d045fcf9d7009450ca6c504ac164adba42dbbd3",
            "0x3d045fcf9d7009450ca6c504ac164adba42dbbd3",
        };
    }
}