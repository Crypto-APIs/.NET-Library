using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetInfosByBlockHash
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseCollectionTest
    {
        [TestMethod]
        public void InvalidBlockHeight()
        {
            var response = Manager.Blockchains.Transaction.GetInfos(Coin, Network, blockHash: "qwe");

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Transaction not found", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A BlockHash was inappropriately allowed.")]
        public void BlockHashOutOfRange()
        {
            Manager.Blockchains.Transaction.GetInfos(Coin, Network, blockHash: "");
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Transaction.GetInfos(Coin, Network, BlockHash);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Blockchains.Transaction.GetInfos(Coin, Network, BlockHash, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Blockchains.Transaction.GetInfos(Coin, Network, BlockHash, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Blockchains.Transaction.GetInfos(Coin, Network, BlockHash, skip, limit);
        }

        [TestMethod]
        public override void SkipTooLarge()
        {
            var skip = 20000000;
            var response = GetSkipList(skip: skip);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Transaction not found", response.ErrorMessage);
        }

        protected abstract BtcSimilarCoin Coin { get; }
        protected abstract BtcSimilarNetwork Network { get; }
        protected abstract string BlockHash { get; }
    }
}