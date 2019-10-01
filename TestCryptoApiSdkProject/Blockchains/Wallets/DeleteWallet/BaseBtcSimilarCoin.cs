using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestCryptoApiSdkProject.Blockchains.Wallets.DeleteWallet
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

                Assert.IsNotNull(deleteResponse);
                Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
                Assert.AreEqual($"Wallet {wallet} was successfully deleted!", deleteResponse.Payload.Message);
            }

            var secondGetWalletsResponse = Manager.Blockchains.Wallet.GetWallets<GetWalletsResponse>(NetworkCoin);
            Assert.IsNotNull(secondGetWalletsResponse);
            Assert.IsTrue(string.IsNullOrEmpty(secondGetWalletsResponse.ErrorMessage));
            Assert.IsFalse(secondGetWalletsResponse.Wallets.Any());
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}