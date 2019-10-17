using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.GetInfosByBlockHeight
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseCollectionTest
    {
        [TestMethod]
        public void InvalidBlockHeight()
        {
            var blockHeight = int.MaxValue;
            var response = Manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(NetworkCoin, blockHeight);

            AssertErrorMessage(response, "Transaction not found");
        }

        [TestMethod]
        public override void SkipTooLarge()
        {
            var skip = 20000000;
            var response = GetSkipList(skip);

            Assert.IsNotNull(response, $"'{nameof(response)}' must not be null");
            Assert.IsFalse(
                string.IsNullOrEmpty(response.ErrorMessage),
                $"'{nameof(response.ErrorMessage)}' must not be null");
            Assert.AreEqual("Transaction not found", response.ErrorMessage, "'ErrorMessage' is wrong");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A BlockHeight was inappropriately allowed.")]
        public void TestBlockHeightOutOfRange()
        {
            var blockHeight = -552875;
            Manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(NetworkCoin, blockHeight);
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(NetworkCoin, BlockHeight);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(NetworkCoin, BlockHeight, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(NetworkCoin, BlockHeight, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(NetworkCoin, BlockHeight, skip, limit);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract int BlockHeight { get; }
    }
}