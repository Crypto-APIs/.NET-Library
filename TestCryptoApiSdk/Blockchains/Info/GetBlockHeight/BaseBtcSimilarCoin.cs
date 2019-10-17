using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Info.GetBlockHeight
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Info.GetBlockHeight<GetBtcHashInfoResponse>(NetworkCoin, BlockHeight);
            AssertNullErrorMessage(response);
            Assert.AreEqual(BlockHeight, response.HashInfo.Height, $"'{nameof(BlockHeight)}' is wrong");
        }

        [TestMethod]
        public void IncorrectedBlock()
        {
            var blockHeight = -123;
            var response = Manager.Blockchains.Info.GetBlockHeight<GetBtcHashInfoResponse>(NetworkCoin, blockHeight);

            AssertErrorMessage(response, "Block not found");
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract int BlockHeight { get; }
    }
}