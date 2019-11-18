using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CryptoApisLibrary.Tests.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public class EthSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin, string blockHash)
        {
            var response = Manager.Blockchains.Info.GetBlockHash<GetEthHashInfoResponse>(networkCoin, blockHash);

            AssertNullErrorMessage(response);
            Assert.AreEqual(blockHash, response.HashInfo.Hash, $"'{nameof(blockHash)}' is wrong");
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void InvalidBlockHash_ErrorMessage(NetworkCoin networkCoin)
        {
            var blockHash = "qwe'asd";

            var response = Manager.Blockchains.Info.GetBlockHash<GetEthHashInfoResponse>(networkCoin, blockHash);

            AssertErrorMessage(response, "Block not found");
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A BlockHash of null was inappropriately allowed.")]
        public void NullBlockHash_Exception(NetworkCoin networkCoin)
        {
            string blockHash = null;

            Manager.Blockchains.Info.GetBlockHash<GetEthHashInfoResponse>(networkCoin, blockHash);
        }

        private static IEnumerable<object[]> GetTestData
        {
            get
            {
                yield return new object[] { NetworkCoin.EthMainNet, Features.CorrectBlockHash.EthMainNet };
                yield return new object[] { NetworkCoin.EthRinkeby, Features.CorrectBlockHash.EthRinkenby };
                yield return new object[] { NetworkCoin.EthRopsten, Features.CorrectBlockHash.EthRopsten };
                yield return new object[] { NetworkCoin.EtcMainNet, Features.CorrectBlockHash.EtcMainNet };
                yield return new object[] { NetworkCoin.EtcMorden, Features.CorrectBlockHash.EtcMorden };
            }
        }
    }
}