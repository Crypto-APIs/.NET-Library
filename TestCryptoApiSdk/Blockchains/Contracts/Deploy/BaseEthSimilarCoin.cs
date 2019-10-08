using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Blockchains.Contracts.Deploy
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [Ignore] // todo: no funds for testing
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                NetworkCoin, FromAddress, GasPrice, GasLimit, PrivateKey, ByteCode);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Hex), 
                $"'{nameof(response.Payload.Hex)}' must not be null");
        }

        [TestMethod]
        public void InsufficientFunds()
        {
            var response = Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                NetworkCoin, FromAddress, GasPrice, GasLimit, PrivateKey, ByteCode);

            AssertErrorMessage(response, "insufficient funds for gas * price + value");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress()
        {
            string fromAddress = null;
            Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                NetworkCoin, fromAddress, GasPrice, GasLimit, PrivateKey, ByteCode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An PrivateKey of null was inappropriately allowed.")]
        public void NullPrivateKey()
        {
            string privateKey = null;
            Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                NetworkCoin, FromAddress, GasPrice, GasLimit, privateKey, ByteCode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An ByteCode of null was inappropriately allowed.")]
        public void NullByteCode()
        {
            string byteCode = null;
            Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                NetworkCoin, FromAddress, GasPrice, GasLimit, PrivateKey, byteCode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An GasPrice of null was inappropriately allowed.")]
        public void InvalidGasPrice()
        {
            var gasPrice = 0;
            Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                NetworkCoin, FromAddress, gasPrice, GasLimit, PrivateKey, ByteCode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An GasLimit of null was inappropriately allowed.")]
        public void InvalidGasLimit()
        {
            var gasPrice = 0;
            Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                NetworkCoin, FromAddress, gasPrice, GasLimit, PrivateKey, ByteCode);
        }

        [TestMethod]
        public void InvalidByteCode()
        {
            var byteCode = "qwe";
            var response = Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                NetworkCoin, FromAddress, GasPrice, GasLimit, PrivateKey, byteCode);

            AssertErrorMessage(response, "Byte code is not in the correct format");
        }

        [TestMethod]
        public void InvalidAddress()
        {
            var fromAddress = "qwe";
            var response = Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                NetworkCoin, fromAddress, GasPrice, GasLimit, PrivateKey, ByteCode);

            AssertErrorMessage(response, $"{fromAddress}  is not a valid Ethereum address");
        }

        [TestMethod]
        public void InvalidPrivateKey()
        {
            var privateKey = "qwe";
            var response = Manager.Blockchains.Contract.Deploy<EthDeployContractResponse>(
                NetworkCoin, FromAddress, GasPrice, GasLimit, privateKey, ByteCode);

            AssertErrorMessage(response, "Could not sign the transaction");
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        private double GasPrice { get; } = 21000000000;
        private double GasLimit { get; } = 2100000;
        private string PrivateKey { get; } = "4f75aff19dd7acbf7c4d5d6f736176a3fe2db1ec9b60cc11d30dc3c343520ed1";
        private string FromAddress { get; } = "0xe7cc96ba0562dfba61a55c8dd2e162a30942f402";
        private string ByteCode { get; } = "0x60806040523480156200001157600080fd5b50336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506040805190810160405280600481526020017f4d464b54000000000000000000000000000000000000000000000000000000008fffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156116b457600080fd5b80600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373fffff";
    }
}