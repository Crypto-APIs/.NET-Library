using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Info.GetLatestBlock
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Info.GetLatestBlock<GetBtcHashInfoResponse>(NetworkCoin);

            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.HashInfo.Chainwork));
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}