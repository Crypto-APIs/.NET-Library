using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System.Collections.Generic;
using System.Threading;

namespace CryptoApisLibrary.Modules.Blockchains.Wallets
{
    internal partial class BlockchainWalletModule
    {
        public T CreateWallet<T>(NetworkCoin networkCoin, string walletName, IEnumerable<string> addresses)
            where T : WalletInfoResponse, new()
        {
            return CreateWalletAsync<T>(CancellationToken.None, networkCoin, walletName, addresses).GetAwaiter().GetResult();
        }

        public T CreateHdWallet<T>(NetworkCoin networkCoin,
            string walletName, int addressCount, string password)
            where T : HdWalletInfoResponse, new()
        {
            return CreateHdWalletAsync<T>(CancellationToken.None, networkCoin,
                walletName, addressCount, password).GetAwaiter().GetResult();
        }

        public T GetWallets<T>(NetworkCoin networkCoin)
            where T : GetWalletsResponse, new()
        {
            return GetWalletsAsync<T>(CancellationToken.None, networkCoin).GetAwaiter().GetResult();
        }

        public T GetHdWallets<T>(NetworkCoin networkCoin)
            where T : GetHdWalletsResponse, new()
        {
            return GetHdWalletsAsync<T>(CancellationToken.None, networkCoin).GetAwaiter().GetResult();
        }

        public T GetWalletInfo<T>(NetworkCoin networkCoin, string walletName)
            where T : WalletInfoResponse, new()
        {
            return GetWalletInfoAsync<T>(CancellationToken.None, networkCoin, walletName).GetAwaiter().GetResult();
        }

        public T GetHdWalletInfo<T>(NetworkCoin networkCoin, string walletName)
            where T : HdWalletInfoResponse, new()
        {
            return GetHdWalletInfoAsync<T>(CancellationToken.None, networkCoin, walletName).GetAwaiter().GetResult();
        }

        public T AddAddress<T>(NetworkCoin networkCoin, string walletName, IEnumerable<string> addresses)
            where T : WalletInfoResponse, new()
        {
            return AddAddressAsync<T>(CancellationToken.None, networkCoin, walletName, addresses).GetAwaiter().GetResult();
        }

        public T GenerateAddress<T>(NetworkCoin networkCoin, string walletName)
            where T : GenerateWalletAddressResponse, new()
        {
            return GenerateAddressAsync<T>(CancellationToken.None, networkCoin, walletName).GetAwaiter().GetResult();
        }

        public T GenerateHdAddress<T>(NetworkCoin networkCoin, string walletName,
            int addressCount, string encryptedPassword)
            where T : HdWalletInfoResponse, new()
        {
            return GenerateHdAddressAsync<T>(CancellationToken.None, networkCoin,
                walletName, addressCount, encryptedPassword).GetAwaiter().GetResult();
        }

        public T RemoveAddress<T>(NetworkCoin networkCoin, string walletName, string address)
            where T : RemoveAddressResponse, new()
        {
            return RemoveAddressAsync<T>(CancellationToken.None, networkCoin, walletName, address).GetAwaiter().GetResult();
        }

        public T DeleteWallet<T>(NetworkCoin networkCoin, string walletName)
            where T : DeleteWalletResponse, new()
        {
            return DeleteWalletAsync<T>(CancellationToken.None, networkCoin, walletName).GetAwaiter().GetResult();
        }

        public T DeleteHdWallet<T>(NetworkCoin networkCoin, string walletName) where T : DeleteWalletResponse, new()
        {
            return DeleteHdWalletAsync<T>(CancellationToken.None, networkCoin, walletName).GetAwaiter().GetResult();
        }
    }
}