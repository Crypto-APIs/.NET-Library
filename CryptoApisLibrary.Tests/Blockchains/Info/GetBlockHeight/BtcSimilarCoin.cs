using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CryptoApisLibrary.Tests.Blockchains.Info.GetBlockHeight
{
    [TestClass]
    public class BtcSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin, int blockHeight)
        {
            var response = Manager.Blockchains.Info.GetBlockHeight<GetBtcHashInfoResponse>(networkCoin, blockHeight);

            AssertNullErrorMessage(response);
            Assert.AreEqual(blockHeight, response.HashInfo.Height, $"'{nameof(blockHeight)}' is wrong");
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void InvalidBlockHeight_ErrorMessage(NetworkCoin networkCoin)
        {
            var blockHeight = -123;

            var response = Manager.Blockchains.Info.GetBlockHeight<GetBtcHashInfoResponse>(networkCoin, blockHeight);

            AssertErrorMessage(response, "Block not found");
        }

        private static IEnumerable<object[]> GetTestData
        {
            get
            {
                yield return new object[] { NetworkCoin.BchMainNet, Features.CorrectBlockHeight.BchMainNet };
                yield return new object[] { NetworkCoin.BchTestNet, Features.CorrectBlockHeight.BchTestnet };
                yield return new object[] { NetworkCoin.BtcMainNet, Features.CorrectBlockHeight.BtcMainNet };
                yield return new object[] { NetworkCoin.BtcTestNet, Features.CorrectBlockHeight.BtcTestNet };
                yield return new object[] { NetworkCoin.DashMainNet, Features.CorrectBlockHeight.DashMainNet };
                yield return new object[] { NetworkCoin.DashTestNet, Features.CorrectBlockHeight.DashTestnet };
                yield return new object[] { NetworkCoin.DogeMainNet, Features.CorrectBlockHeight.DogeMainNet };
                yield return new object[] { NetworkCoin.DogeTestNet, Features.CorrectBlockHeight.DogeTestnet };
                yield return new object[] { NetworkCoin.LtcMainNet, Features.CorrectBlockHeight.LtcMainNet };
                yield return new object[] { NetworkCoin.LtcTestNet, Features.CorrectBlockHeight.LtcTestnet };
            }
        }
    }
}