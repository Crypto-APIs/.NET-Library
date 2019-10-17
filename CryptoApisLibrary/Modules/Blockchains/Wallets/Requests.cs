using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.Misc;
using CryptoApisLibrary.RequestTypes;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoApisLibrary.Modules.Blockchains.Wallets
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
        }

        public IRestRequest CreateWallet(NetworkCoin networkCoin, string walletName, IEnumerable<string> addresses)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));
            if (addresses == null)
                throw new ArgumentNullException(nameof(addresses));

            var enumerable = addresses as string[] ?? addresses.ToArray();
            if (!enumerable.Any())
                throw new ArgumentNullException(nameof(addresses), "Addresses is empty");

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/wallets",
                new CreateWalletRequest(walletName, enumerable));
        }

        public IRestRequest CreateHdWallet(NetworkCoin networkCoin,
            string walletName, int addressCount, string password)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));
            if (addressCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(addressCount), addressCount, $"AddressCount is negative or zero");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/wallets/hd",
                new CreateHdWalletRequest(walletName, password, addressCount));
        }

        public IRestRequest GetWallets(NetworkCoin networkCoin)
        {
            return Request.Get($"{Consts.Blockchain}/{networkCoin}/wallets");
        }

        public IRestRequest GetHdWallets(NetworkCoin networkCoin)
        {
            return Request.Get($"{Consts.Blockchain}/{networkCoin}/wallets/hd");
        }

        public IRestRequest GetWalletInfo(NetworkCoin networkCoin, string walletName)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));

            return Request.Get($"{Consts.Blockchain}/{networkCoin}/wallets/{walletName}");
        }

        public IRestRequest GetHdWalletInfo(NetworkCoin networkCoin, string walletName)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));

            return Request.Get($"{Consts.Blockchain}/{networkCoin}/wallets/hd/{walletName}");
        }

        public IRestRequest AddAddress(NetworkCoin networkCoin, string walletName, IEnumerable<string> addresses)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));
            if (addresses == null)
                throw new ArgumentNullException(nameof(addresses));

            var enumerable = addresses as string[] ?? addresses.ToArray();
            if (!enumerable.Any())
                throw new ArgumentNullException(nameof(addresses), "Addresses is empty");

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/wallets/{walletName}/addresses",
                new AddAddressToWalletRequest(enumerable));
        }

        public IRestRequest GenerateAddress(NetworkCoin networkCoin, string walletName)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/wallets/{walletName}/addresses/generate");
        }

        public IRestRequest GenerateHdAddress(NetworkCoin networkCoin, string walletName,
            int addressCount, string encryptedPassword)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));
            if (addressCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(addressCount), addressCount, $"AddressCount is negative or zero");
            if (string.IsNullOrEmpty(encryptedPassword))
                throw new ArgumentNullException(nameof(encryptedPassword));

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/wallets/hd/{walletName}/addresses/generate",
                new GenerateHdWalletAddressRequest(addressCount, encryptedPassword));
        }

        public IRestRequest RemoveAddress(NetworkCoin networkCoin, string walletName, string address)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            return Request.Delete($"{Consts.Blockchain}/{networkCoin}/wallets/{walletName}/address/{address}");
        }

        public IRestRequest DeleteWallet(NetworkCoin networkCoin, string walletName)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));

            return Request.Delete($"{Consts.Blockchain}/{networkCoin}/wallets/{walletName}");
        }

        public IRestRequest DeleteHdWallet(NetworkCoin networkCoin, string walletName)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));

            return Request.Delete($"{Consts.Blockchain}/{networkCoin}/wallets/hd/{walletName}");
        }

        private CryptoApiRequest Request { get; }
    }
}