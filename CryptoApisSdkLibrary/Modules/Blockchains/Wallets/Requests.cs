using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.RequestTypes;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Wallets
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
        }

        public IRestRequest CreateWallet(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string walletName, IEnumerable<string> addresses)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));
            if (addresses == null)
                throw new ArgumentNullException(nameof(addresses));

            var enumerable = addresses as string[] ?? addresses.ToArray();
            if (!enumerable.Any())
                throw new ArgumentNullException(nameof(addresses), "Addresses is empty");

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/wallets",
                new CreateWalletRequest(walletName, enumerable));
        }

        public IRestRequest CreateHdWallet(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string walletName, int addressCount, string password)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));
            if (addressCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(addressCount), addressCount, $"AddressCount is negative or zero");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/wallets/hd",
                new CreateHdWalletRequest(walletName, password, addressCount));
        }

        public IRestRequest GetWallets(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/wallets");
        }

        public IRestRequest GetHdWallets(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/wallets/hd");
        }

        public IRestRequest GetWalletInfo(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));

            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/wallets/{walletName}");
        }

        public IRestRequest GetHdWalletInfo(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));

            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/wallets/hd/{walletName}");
        }

        public IRestRequest AddAddress(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string walletName, IEnumerable<string> addresses)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));
            if (addresses == null)
                throw new ArgumentNullException(nameof(addresses));

            var enumerable = addresses as string[] ?? addresses.ToArray();
            if (!enumerable.Any())
                throw new ArgumentNullException(nameof(addresses), "Addresses is empty");

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/wallets/{walletName}/addresses",
                new AddAddressToWalletRequest(enumerable));
        }

        public IRestRequest GenerateAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/wallets/{walletName}/addresses/generate");
        }

        public IRestRequest GenerateHdAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName,
            int addressCount, string encryptedPassword)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));
            if (addressCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(addressCount), addressCount, $"AddressCount is negative or zero");
            if (string.IsNullOrEmpty(encryptedPassword))
                throw new ArgumentNullException(nameof(encryptedPassword));

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/wallets/hd/{walletName}/addresses/generate",
                new GenerateHdWalletAddressRequest(addressCount, encryptedPassword));
        }

        public IRestRequest RemoveAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName, string address)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            return Request.Delete($"{Consts.Blockchain}/{coin}/{network}/wallets/{walletName}/address/{address}");
        }

        public IRestRequest DeleteWallet(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));

            return Request.Delete($"{Consts.Blockchain}/{coin}/{network}/wallets/{walletName}");
        }

        public IRestRequest DeleteHdWallet(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));

            return Request.Delete($"{Consts.Blockchain}/{coin}/{network}/wallets/hd/{walletName}");
        }

        private CryptoApiRequest Request { get; }
    }
}