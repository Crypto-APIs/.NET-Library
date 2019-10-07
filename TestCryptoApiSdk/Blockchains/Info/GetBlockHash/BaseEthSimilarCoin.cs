using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace TestCryptoApiSdk.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Info.GetBlockHash<GetEthHashInfoResponse>(NetworkCoin, BlockHash);

            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);
            Assert.AreEqual(BlockHash, response.HashInfo.Hash);
        }

        [TestMethod]
        public void IncorrectedBlock()
        {
            var response = Manager.Blockchains.Info.GetBlockHash<GetEthHashInfoResponse>(NetworkCoin, blockHash: "qwe");

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "Block not found");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BlockHash of null was inappropriately allowed.")]
        public void NullBlockHash()
        {
            Manager.Blockchains.Info.GetBlockHash<GetEthHashInfoResponse>(NetworkCoin, blockHash: null);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string BlockHash { get; }
    }
}