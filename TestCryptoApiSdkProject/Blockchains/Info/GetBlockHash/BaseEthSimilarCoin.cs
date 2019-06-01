using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Info.GetBlockHash(Coin, Network, BlockHash);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual(BlockHash, response.HashInfo.Hash);
        }

        [TestMethod]
        public void IncorrectedBlock()
        {
            var response = Manager.Blockchains.Info.GetBlockHash(Coin, Network, blockHash: "qwe");

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Block not found", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BlockHash of null was inappropriately allowed.")]
        public void NullBlockHash()
        {
            Manager.Blockchains.Info.GetBlockHash(Coin, Network, blockHash: null);
        }

        protected abstract EthSimilarCoin Coin { get; }
        protected abstract EthSimilarNetwork Network { get; }
        protected abstract string BlockHash { get; }
    }
}