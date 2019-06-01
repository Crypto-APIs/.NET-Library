using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetInfosByBlockHeight
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseCollectionTest
    {
        [TestMethod]
        public void InvalidBlockHeight()
        {
            var response = Manager.Blockchains.Transaction.GetInfos(Coin, Network, blockHeight: int.MaxValue);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Transaction not found", response.ErrorMessage);
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A BlockHeight was inappropriately allowed.")]
        public void TestBlockHeightOutOfRange()
        {
            Manager.Blockchains.Transaction.GetInfos(Coin, Network, blockHeight: -552875);
        }

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

        protected abstract BtcSimilarCoin Coin { get; }
        protected abstract BtcSimilarNetwork Network { get; }
        protected abstract int BlockHeight { get; }
    }
}