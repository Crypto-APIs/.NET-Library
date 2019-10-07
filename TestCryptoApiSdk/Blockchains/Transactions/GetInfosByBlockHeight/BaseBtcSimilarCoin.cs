using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace TestCryptoApiSdk.Blockchains.Transactions.GetInfosByBlockHeight
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseCollectionTest
    {
        [TestMethod]
        public void InvalidBlockHeight()
        {
            var response = Manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(NetworkCoin, blockHeight: int.MaxValue);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "Transaction not found");
        }

        [TestMethod]
        public override void SkipTooLarge()
        {
            var skip = 20000000;
            var response = GetSkipList(skip: skip);

            Assert.IsNotNull(response, $"'{nameof(response)}' must not be null");
            Assert.IsFalse(
                string.IsNullOrEmpty(response.ErrorMessage),
                $"'{nameof(response.ErrorMessage)}' must not be null");
            Assert.AreEqual("Transaction not found", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A BlockHeight was inappropriately allowed.")]
        public void TestBlockHeightOutOfRange()
        {
            Manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(NetworkCoin, blockHeight: -552875);
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(NetworkCoin, BlockHeight);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(NetworkCoin, BlockHeight, skip: skip);
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