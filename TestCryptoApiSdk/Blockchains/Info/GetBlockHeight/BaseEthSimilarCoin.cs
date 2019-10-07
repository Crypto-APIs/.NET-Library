using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Info.GetBlockHeight
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Info.GetBlockHeight<GetEthHashInfoResponse>(NetworkCoin, BlockHeight);

            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);
            Assert.AreEqual(BlockHeight, response.HashInfo.Height);
        }

        [TestMethod]
        public void IncorrectedBlock()
        {
            var response = Manager.Blockchains.Info.GetBlockHeight<GetEthHashInfoResponse>(NetworkCoin, blockHeight: -123);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "Block not found");
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract int BlockHeight { get; }
    }
}