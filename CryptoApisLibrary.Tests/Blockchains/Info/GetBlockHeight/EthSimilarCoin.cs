using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CryptoApisLibrary.Tests.Blockchains.Info.GetBlockHeight
{
    [TestClass]
    public class EthSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin, int blockHeight)
        {
            var response = Manager.Blockchains.Info.GetBlockHeight<GetEthHashInfoResponse>(networkCoin, blockHeight);

            AssertNullErrorMessage(response);
            Assert.AreEqual(blockHeight, response.HashInfo.Height, $"'{nameof(blockHeight)}' is wrong");
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void InvalidBlockHeight_ErrorMessage(NetworkCoin networkCoin)
        {
            var blockHeight = -123;

            var response = Manager.Blockchains.Info.GetBlockHeight<GetEthHashInfoResponse>(networkCoin, blockHeight);

            AssertErrorMessage(response, "Block not found");
        }

        private static IEnumerable<object[]> GetTestData
        {
            get
            {
                yield return new object[] { NetworkCoin.EthMainNet, Features.CorrectBlockHeight.EthMainNet };
                yield return new object[] { NetworkCoin.EthRinkeby, Features.CorrectBlockHeight.EthRinkenby };
                yield return new object[] { NetworkCoin.EthRopsten, Features.CorrectBlockHeight.EthRopsten };
                yield return new object[] { NetworkCoin.EtcMainNet, Features.CorrectBlockHeight.EtcMainNet };
                yield return new object[] { NetworkCoin.EtcMorden, Features.CorrectBlockHeight.EtcMorden };
            }
        }
    }
}