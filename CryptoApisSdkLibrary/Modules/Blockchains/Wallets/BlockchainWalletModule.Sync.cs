using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Wallets
{
    internal partial class BlockchainWalletModule
    {
        public T CreateWallet<T>(NetworkCoin networkCoin, string walletName, IEnumerable<string> addresses)
            where T : WalletInfoResponse, new()
        {
            var request = Requests.CreateWallet(networkCoin, walletName, addresses);
            return GetSync<T>(request);
        }

        public T CreateHdWallet<T>(NetworkCoin networkCoin,
            string walletName, int addressCount, string password)
            where T : HdWalletInfoResponse, new()
        {
            var request = Requests.CreateHdWallet(networkCoin, walletName, addressCount, password);
            return GetSync<T>(request);
        }

        public T GetWallets<T>(NetworkCoin networkCoin)
            where T : GetWalletsResponse, new()
        {
            var request = Requests.GetWallets(networkCoin);
            return GetSync<T>(request);
        }

        public T GetHdWallets<T>(NetworkCoin networkCoin)
            where T : GetHdWalletsResponse, new()
        {
            var request = Requests.GetHdWallets(networkCoin);
            return GetSync<T>(request);
        }

        public T GetWalletInfo<T>(NetworkCoin networkCoin, string walletName)
            where T : WalletInfoResponse, new()
        {
            var request = Requests.GetWalletInfo(networkCoin, walletName);
            return GetSync<T>(request);
        }

        public T GetHdWalletInfo<T>(NetworkCoin networkCoin, string walletName)
            where T : HdWalletInfoResponse, new()
        {
            var request = Requests.GetHdWalletInfo(networkCoin, walletName);
            return GetSync<T>(request);
        }

        public T AddAddress<T>(NetworkCoin networkCoin, string walletName, IEnumerable<string> addresses)
            where T : WalletInfoResponse, new()
        {
            var request = Requests.AddAddress(networkCoin, walletName, addresses);
            return GetSync<T>(request);
        }

        public T GenerateAddress<T>(NetworkCoin networkCoin, string walletName)
            where T : GenerateWalletAddressResponse, new()
        {
            var request = Requests.GenerateAddress(networkCoin, walletName);
            return GetSync<T>(request);
        }

        public T GenerateHdAddress<T>(NetworkCoin networkCoin, string walletName,
            int addressCount, string encryptedPassword)
            where T : HdWalletInfoResponse, new()
        {
            var request = Requests.GenerateHdAddress(networkCoin, walletName, addressCount, encryptedPassword);
            return GetSync<T>(request);
        }

        public T RemoveAddress<T>(NetworkCoin networkCoin, string walletName, string address)
            where T : RemoveAddressResponse, new()
        {
            var request = Requests.RemoveAddress(networkCoin, walletName, address);
            return GetSync<T>(request);
        }

        public T DeleteWallet<T>(NetworkCoin networkCoin, string walletName)
            where T : DeleteWalletResponse, new()
        {
            var request = Requests.DeleteWallet(networkCoin, walletName);
            return GetSync<T>(request);
        }
    }
}