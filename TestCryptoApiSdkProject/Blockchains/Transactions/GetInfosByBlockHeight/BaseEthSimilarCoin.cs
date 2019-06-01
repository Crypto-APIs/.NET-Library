using System;
using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetInfosByBlockHeight
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Transaction.GetInfos(Coin, Network, BlockHeight);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Blockchains.Transaction.GetInfos(Coin, Network, BlockHeight, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Blockchains.Transaction.GetInfos(Coin, Network, BlockHeight, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Blockchains.Transaction.GetInfos(Coin, Network, BlockHeight, skip, limit);
        }

        [TestMethod]
        public override void SkipTooLarge()
        {
            var skip = 20000000;
            var response = GetSkipList(skip: skip);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Transactions not found!", response.ErrorMessage);
        }

        [TestMethod]
        public void TestInvalidBlockHeight()
        {
            var blockHeight = int.MaxValue;
            var response = Manager.Blockchains.Transaction.GetInfos(Coin, Network, blockHeight);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Transactions not found!", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A BlockHeight was inappropriately allowed.")]
        public void TestBlockHeightOutOfRange()
        {
            var blockHeight = -4173655;
            Manager.Blockchains.Transaction.GetInfos(Coin, Network, blockHeight);
        }

        protected abstract EthSimilarCoin Coin { get; }
        protected abstract EthSimilarNetwork Network { get; }
        protected abstract int BlockHeight { get; }
    }
}