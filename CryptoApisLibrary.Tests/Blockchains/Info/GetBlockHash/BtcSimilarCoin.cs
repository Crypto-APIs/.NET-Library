using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CryptoApisLibrary.Tests.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public class BtcSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin, string blockHash)
        {
            var response = Manager.Blockchains.Info.GetBlockHash<GetBtcHashInfoResponse>(networkCoin, blockHash);

            AssertNullErrorMessage(response);
            Assert.AreEqual(blockHash, response.HashInfo.Hash, $"'{nameof(blockHash)}' is wrong");
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void InvalidBlockHash_ErrorMessage(NetworkCoin networkCoin)
        {
            var blockHash = "qwe'asd";

            var response = Manager.Blockchains.Info.GetBlockHash<GetBtcHashInfoResponse>(networkCoin, blockHash);

            AssertErrorMessage(response, "Block not found");
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A BlockHash of null was inappropriately allowed.")]
        public void NullBlockHash_Exception(NetworkCoin networkCoin)
        {
            string blockHash = null;

            Manager.Blockchains.Info.GetBlockHash<GetBtcHashInfoResponse>(networkCoin, blockHash);
        }

        private static IEnumerable<object[]> GetTestData
        {
            get
            {
                yield return new object[] { NetworkCoin.BchMainNet, Features.CorrectBlockHash.BchMainNet };
                yield return new object[] { NetworkCoin.BchTestNet, Features.CorrectBlockHash.BchTestnet };
                yield return new object[] { NetworkCoin.BtcMainNet, Features.CorrectBlockHash.BtcMainNet };
                yield return new object[] { NetworkCoin.BtcTestNet, Features.CorrectBlockHash.BtcTestNet };
                yield return new object[] { NetworkCoin.DashMainNet, Features.CorrectBlockHash.DashMainNet };
                yield return new object[] { NetworkCoin.DashTestNet, Features.CorrectBlockHash.DashTestnet };
                yield return new object[] { NetworkCoin.DogeMainNet, Features.CorrectBlockHash.DogeMainNet };
                yield return new object[] { NetworkCoin.DogeTestNet, Features.CorrectBlockHash.DogeTestnet };
                yield return new object[] { NetworkCoin.LtcMainNet, Features.CorrectBlockHash.LtcMainNet };
                yield return new object[] { NetworkCoin.LtcTestNet, Features.CorrectBlockHash.LtcTestnet };
            }
        }
    }
}