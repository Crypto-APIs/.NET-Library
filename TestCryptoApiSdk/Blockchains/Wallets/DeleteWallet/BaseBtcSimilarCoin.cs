using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestCryptoApiSdk.Blockchains.Wallets.DeleteWallet
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var getWalletsResponse = Manager.Blockchains.Wallet.GetWallets<GetWalletsResponse>(NetworkCoin);
            Assert.IsNotNull(getWalletsResponse);
            Assert.IsTrue(string.IsNullOrEmpty(getWalletsResponse.ErrorMessage));

            foreach (var wallet in getWalletsResponse.Wallets)
            {
                var deleteResponse = Manager.Blockchains.Wallet.DeleteWallet<DeleteWalletResponse>(NetworkCoin, wallet);

                AssertNotNullResponse(deleteResponse);
                AssertNullErrorMessage(deleteResponse);
                Assert.AreEqual($"Wallet {wallet} was successfully deleted!", deleteResponse.Payload.Message);
            }

            var secondGetWalletsResponse = Manager.Blockchains.Wallet.GetWallets<GetWalletsResponse>(NetworkCoin);
            AssertNotNullResponse(secondGetWalletsResponse);
            AssertNullErrorMessage(secondGetWalletsResponse);
            AssertEmptyCollection(nameof(secondGetWalletsResponse.Wallets), secondGetWalletsResponse.Wallets);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}