using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace TestCryptoApiSdk.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Info.GetBlockHash<GetBtcHashInfoResponse>(NetworkCoin, BlockHash);

            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);
            Assert.AreEqual(BlockHash, response.HashInfo.Hash);
        }

        [TestMethod]
        public void BtcMainIncorrectedBlock()
        {
            var response = Manager.Blockchains.Info.GetBlockHash<GetBtcHashInfoResponse>(NetworkCoin, blockHash: "qwe");

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "Blockchain connection error: ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BlockHash of null was inappropriately allowed.")]
        public void BtcNullBlockHash()
        {
            Manager.Blockchains.Info.GetBlockHash<GetBtcHashInfoResponse>(NetworkCoin, blockHash: null);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string BlockHash { get; }
    }
}