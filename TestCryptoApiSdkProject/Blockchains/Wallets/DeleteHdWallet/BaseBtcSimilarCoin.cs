using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestCryptoApiSdkProject.Blockchains.Wallets.DeleteHdWallet
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        protected abstract BtcSimilarCoin Coin { get; }
        protected abstract BtcSimilarNetwork Network { get; }

        [TestMethod]
        public void GeneralTest()
        {
            var getWalletsResponse = Manager.Blockchains.Wallet.GetHdWallets(Coin, Network);
            Assert.IsNotNull(getWalletsResponse);
            Assert.IsTrue(string.IsNullOrEmpty(getWalletsResponse.ErrorMessage));

            foreach (var wallet in getWalletsResponse.Wallets)
            {
                var deleteResponse = Manager.Blockchains.Wallet.DeleteHdWallet(Coin, Network, wallet);

                Assert.IsNotNull(deleteResponse);
                Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
                Assert.AreEqual($"Wallet {wallet} was successfully deleted!", deleteResponse.Payload.Message);
            }

            var secondGetWalletsResponse = Manager.Blockchains.Wallet.GetHdWallets(Coin, Network);
            Assert.IsNotNull(secondGetWalletsResponse);
            Assert.IsTrue(string.IsNullOrEmpty(secondGetWalletsResponse.ErrorMessage));
            Assert.IsFalse(secondGetWalletsResponse.Wallets.Any());
        }
    }
}