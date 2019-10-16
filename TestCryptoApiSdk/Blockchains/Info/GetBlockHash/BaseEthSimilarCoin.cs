using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Info.GetBlockHash<GetEthHashInfoResponse>(NetworkCoin, BlockHash);

            AssertNullErrorMessage(response);
            Assert.AreEqual(BlockHash, response.HashInfo.Hash, $"'{nameof(BlockHash)}' is wrong");
        }

        [TestMethod]
        public void IncorrectedBlock()
        {
            var blockHash = "qwe'asd";
            var response = Manager.Blockchains.Info.GetBlockHash<GetEthHashInfoResponse>(NetworkCoin, blockHash);

            AssertErrorMessage(response, "Block not found");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BlockHash of null was inappropriately allowed.")]
        public void NullBlockHash()
        {
            string blockHash = null;
            Manager.Blockchains.Info.GetBlockHash<GetEthHashInfoResponse>(NetworkCoin, blockHash);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string BlockHash { get; }
    }
}