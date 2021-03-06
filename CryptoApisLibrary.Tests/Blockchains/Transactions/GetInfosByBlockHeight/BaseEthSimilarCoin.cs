﻿using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Transactions.GetInfosByBlockHeight
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseCollectionTest
    {
        [Ignore] //todo: random sequence of collection elements
        [TestMethod]
        public override void MainTest()
        {
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Transaction.GetInfos<GetEthTransactionInfosResponse>(NetworkCoin, BlockHeight);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Blockchains.Transaction.GetInfos<GetEthTransactionInfosResponse>(NetworkCoin, BlockHeight, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Blockchains.Transaction.GetInfos<GetEthTransactionInfosResponse>(NetworkCoin, BlockHeight, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Blockchains.Transaction.GetInfos<GetEthTransactionInfosResponse>(NetworkCoin, BlockHeight, skip, limit);
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
            Assert.AreEqual("Transactions not found!", response.ErrorMessage, "'ErrorMessage' is wrong");
        }

        [TestMethod]
        public void TestInvalidBlockHeight()
        {
            var blockHeight = int.MaxValue;
            var response = Manager.Blockchains.Transaction.GetInfos<GetEthTransactionInfosResponse>(NetworkCoin, blockHeight);

            AssertErrorMessage(response, "Transactions not found!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A BlockHeight was inappropriately allowed.")]
        public void TestBlockHeightOutOfRange()
        {
            var blockHeight = -4173655;
            Manager.Blockchains.Transaction.GetInfos<GetEthTransactionInfosResponse>(NetworkCoin, blockHeight);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract int BlockHeight { get; }
    }
}