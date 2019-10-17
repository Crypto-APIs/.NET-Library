using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.GetInfosByBlockHash
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseCollectionTest
    {
        [TestMethod]
        public void InvalidBlockHeight()
        {
            var blockHash = "qw'e";
            var response = Manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(NetworkCoin, blockHash);

            AssertErrorMessage(response, "Transaction not found");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A BlockHash was inappropriately allowed.")]
        public void BlockHashOutOfRange()
        {
            string blockHash = null;
            Manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(NetworkCoin, blockHash);
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(NetworkCoin, BlockHash);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(NetworkCoin, BlockHash, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(NetworkCoin, BlockHash, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(NetworkCoin, BlockHash, skip, limit);
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

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string BlockHash { get; }
    }
}