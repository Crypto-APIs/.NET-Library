using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Info.GetBlockHash<GetBtcHashInfoResponse>(NetworkCoin, BlockHash);

            AssertNullErrorMessage(response);
            Assert.AreEqual(BlockHash, response.HashInfo.Hash, $"'{nameof(BlockHash)}' is wrong");
        }

        [TestMethod]
        public void BtcMainIncorrectedBlock()
        {
            var blockHash = "qwe'asd";
            var response = Manager.Blockchains.Info.GetBlockHash<GetBtcHashInfoResponse>(NetworkCoin, blockHash);

            AssertErrorMessage(response, "Block not found");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BlockHash of null was inappropriately allowed.")]
        public void BtcNullBlockHash()
        {
            string blockHash = null;
            Manager.Blockchains.Info.GetBlockHash<GetBtcHashInfoResponse>(NetworkCoin, blockHash);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string BlockHash { get; }
    }
}