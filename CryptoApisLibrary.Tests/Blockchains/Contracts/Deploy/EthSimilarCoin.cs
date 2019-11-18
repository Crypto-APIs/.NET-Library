using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CryptoApisLibrary.Tests.Blockchains.Contracts.Deploy
{
    [TestClass]
    public class EthSimilarCoin : BaseTest
    {
        [Ignore] // todo: no funds for testing
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin, string fromAddress)
        {
            var gasPrice = 21000000000;
            var gasLimit = 2100000;
            var privateKey = "4f75aff19dd7acbf7c4d5d6f736176a3fe2db1ec9b60cc11d30dc3c343520ed1";
            var byteCode = "0x60806040523480156200001157600080fd5b50336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506040805190810160405280600481526020017f4d464b54000000000000000000000000000000000000000000000000000000008fffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156116b457600080fd5b80600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373fffff";

            var response = Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                networkCoin, fromAddress, gasPrice, gasLimit, privateKey, byteCode);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Hex),
                $"'{nameof(response.Payload.Hex)}' must not be null");
        }

        [Ignore] // todo: no funds for testing
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void InsufficientFunds_ErrorMessage(NetworkCoin networkCoin, string fromAddress)
        {
            var gasPrice = 21000000000;
            var gasLimit = 2100000;
            var privateKey = "4f75aff19dd7acbf7c4d5d6f736176a3fe2db1ec9b60cc11d30dc3c343520ed1";
            var byteCode = "0x60806040523480156200001157600080fd5b50336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506040805190810160405280600481526020017f4d464b54000000000000000000000000000000000000000000000000000000008fffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156116b457600080fd5b80600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373fffff";

            var response = Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                networkCoin, fromAddress, gasPrice, gasLimit, privateKey, byteCode);

            AssertErrorMessage(response, "insufficient funds for gas * price + value");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An GasLimit of null was inappropriately allowed.")]
        public void InvalidGasLimit_Exception(NetworkCoin networkCoin, string fromAddress)
        {
            var gasPrice = 21000000000;
            var gasLimit = 0;
            var privateKey = "4f75aff19dd7acbf7c4d5d6f736176a3fe2db1ec9b60cc11d30dc3c343520ed1";
            var byteCode = "0x60806040523480156200001157600080fd5b50336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506040805190810160405280600481526020017f4d464b54000000000000000000000000000000000000000000000000000000008fffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156116b457600080fd5b80600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373fffff";

            Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                networkCoin, fromAddress, gasPrice, gasLimit, privateKey, byteCode);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An GasPrice of null was inappropriately allowed.")]
        public void InvalidGasPrice_Exception(NetworkCoin networkCoin, string fromAddress)
        {
            var gasPrice = 0;
            var gasLimit = 2100000;
            var privateKey = "4f75aff19dd7acbf7c4d5d6f736176a3fe2db1ec9b60cc11d30dc3c343520ed1";
            var byteCode = "0x60806040523480156200001157600080fd5b50336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506040805190810160405280600481526020017f4d464b54000000000000000000000000000000000000000000000000000000008fffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156116b457600080fd5b80600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373fffff";

            Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                networkCoin, fromAddress, gasPrice, gasLimit, privateKey, byteCode);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress_Exception(NetworkCoin networkCoin)
        {
            string fromAddress = null;
            var gasPrice = 21000000000;
            var gasLimit = 2100000;
            var privateKey = "4f75aff19dd7acbf7c4d5d6f736176a3fe2db1ec9b60cc11d30dc3c343520ed1";
            var byteCode = "0x60806040523480156200001157600080fd5b50336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506040805190810160405280600481526020017f4d464b54000000000000000000000000000000000000000000000000000000008fffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156116b457600080fd5b80600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373fffff";

            Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                networkCoin, fromAddress, gasPrice, gasLimit, privateKey, byteCode);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void UnexistingAddress_ErrorMessage(NetworkCoin networkCoin)
        {
            var fromAddress = "q'we";
            var gasPrice = 21000000000;
            var gasLimit = 2100000;
            var privateKey = "4f75aff19dd7acbf7c4d5d6f736176a3fe2db1ec9b60cc11d30dc3c343520ed1";
            var byteCode = "0x60806040523480156200001157600080fd5b50336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506040805190810160405280600481526020017f4d464b54000000000000000000000000000000000000000000000000000000008fffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156116b457600080fd5b80600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373fffff";

            var response = Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                networkCoin, fromAddress, gasPrice, gasLimit, privateKey, byteCode);

            AssertErrorMessage(response, $"{fromAddress}  is not a valid Ethereum address");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentNullException), "An PrivateKey of null was inappropriately allowed.")]
        public void NullPrivateKey_Exception(NetworkCoin networkCoin, string fromAddress)
        {
            var gasPrice = 21000000000;
            var gasLimit = 2100000;
            string privateKey = null;
            var byteCode = "0x60806040523480156200001157600080fd5b50336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506040805190810160405280600481526020017f4d464b54000000000000000000000000000000000000000000000000000000008fffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156116b457600080fd5b80600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373fffff";

            Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                networkCoin, fromAddress, gasPrice, gasLimit, privateKey, byteCode);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void InvalidPrivateKey_ErrorMessage(NetworkCoin networkCoin, string fromAddress)
        {
            var gasPrice = 21000000000;
            var gasLimit = 2100000;
            var privateKey = "qw'e";
            var byteCode = "0x60806040523480156200001157600080fd5b50336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506040805190810160405280600481526020017f4d464b54000000000000000000000000000000000000000000000000000000008fffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156116b457600080fd5b80600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373fffff";

            var response = Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                networkCoin, fromAddress, gasPrice, gasLimit, privateKey, byteCode);

            AssertErrorMessage(response, "Could not sign the transaction");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentNullException), "An ByteCode of null was inappropriately allowed.")]
        public void NullByteCode_Exception(NetworkCoin networkCoin, string fromAddress)
        {
            var gasPrice = 21000000000;
            var gasLimit = 2100000;
            var privateKey = "4f75aff19dd7acbf7c4d5d6f736176a3fe2db1ec9b60cc11d30dc3c343520ed1";
            string byteCode = null;

            Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                networkCoin, fromAddress, gasPrice, gasLimit, privateKey, byteCode);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void InvalidByteCode_ErrorMessage(NetworkCoin networkCoin, string fromAddress)
        {
            var gasPrice = 21000000000;
            var gasLimit = 2100000;
            var privateKey = "4f75aff19dd7acbf7c4d5d6f736176a3fe2db1ec9b60cc11d30dc3c343520ed1";
            var byteCode = "qw'e";

            var response = Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                networkCoin, fromAddress, gasPrice, gasLimit, privateKey, byteCode);

            AssertErrorMessage(response, "Byte code is not in the correct format");
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