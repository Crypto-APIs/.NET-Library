using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Wallets.DeleteWallet
{
    [TestClass]
    public class BtcSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin)
        {
            var getWalletsResponse = Manager.Blockchains.Wallet.GetWallets<GetWalletsResponse>(networkCoin);
            AssertNullErrorMessage(getWalletsResponse);

            foreach (var wallet in getWalletsResponse.Wallets)
            {
                var deleteResponse = Manager.Blockchains.Wallet.DeleteWallet<DeleteWalletResponse>(networkCoin, wallet);
                AssertNullErrorMessage(deleteResponse);
                Assert.AreEqual($"Wallet {wallet} was successfully deleted!", deleteResponse.Payload.Message);
            }

            var secondGetWalletsResponse = Manager.Blockchains.Wallet.GetWallets<GetWalletsResponse>(networkCoin);
            AssertNullErrorMessage(secondGetWalletsResponse);
            AssertEmptyCollection(nameof(secondGetWalletsResponse.Wallets), secondGetWalletsResponse.Wallets);
        }
    }
}