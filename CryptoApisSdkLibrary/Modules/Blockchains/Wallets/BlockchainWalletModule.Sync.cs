using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Wallets
{
    internal partial class BlockchainWalletModule
    {
        public WalletInfoResponse CreateWallet(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string walletName, IEnumerable<string> addresses)
        {
            var request = Requests.CreateWallet(coin, network, walletName, addresses);
            return GetSync<WalletInfoResponse>(request);
        }

        public HdWalletInfoResponse CreateHdWallet(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string walletName, int addressCount, string password)
        {
            var request = Requests.CreateHdWallet(coin, network, walletName, addressCount, password);
            return GetSync<HdWalletInfoResponse>(request);
        }

        public GetWalletsResponse GetWallets(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.GetWallets(coin, network);
            return GetSync<GetWalletsResponse>(request);
        }

        public GetHdWalletsResponse GetHdWallets(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.GetHdWallets(coin, network);
            return GetSync<GetHdWalletsResponse>(request);
        }

        public WalletInfoResponse GetWalletInfo(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            var request = Requests.GetWalletInfo(coin, network, walletName);
            return GetSync<WalletInfoResponse>(request);
        }

        public HdWalletInfoResponse GetHdWalletInfo(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            var request = Requests.GetHdWalletInfo(coin, network, walletName);
            return GetSync<HdWalletInfoResponse>(request);
        }

        public WalletInfoResponse AddAddress(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string walletName, IEnumerable<string> addresses)
        {
            var request = Requests.AddAddress(coin, network, walletName, addresses);
            return GetSync<WalletInfoResponse>(request);
        }

        public GenerateWalletAddressResponse GenerateAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            var request = Requests.GenerateAddress(coin, network, walletName);
            return GetSync<GenerateWalletAddressResponse>(request);
        }

        public HdWalletInfoResponse GenerateHdAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName,
            int addressCount, string encryptedPassword)
        {
            var request = Requests.GenerateHdAddress(coin, network, walletName, addressCount, encryptedPassword);
            return GetSync<HdWalletInfoResponse>(request);
        }

        public RemoveAddressResponse RemoveAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName, string address)
        {
            var request = Requests.RemoveAddress(coin, network, walletName, address);
            return GetSync<RemoveAddressResponse>(request);
        }

        public DeleteWalletResponse DeleteWallet(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            var request = Requests.DeleteWallet(coin, network, walletName);
            return GetSync<DeleteWalletResponse>(request);
        }

        public DeleteWalletResponse DeleteHdWallet(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            var request = Requests.DeleteHdWallet(coin, network, walletName);
            return GetSync<DeleteWalletResponse>(request);
        }
    }
}