using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.RequestTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Wallets
{
    internal class BlockchainWalletModule : BaseModule, IBlockchainWalletModule
    {
        public BlockchainWalletModule(IRestClient client, CryptoApiRequest request) : base(client, request)
        {
        }

        public WalletInfoResponse CreateWallet(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string walletName, IEnumerable<string> addresses)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));
            if (addresses == null)
                throw new ArgumentNullException(nameof(addresses));

            var enumerable = addresses as string[] ?? addresses.ToArray();
            if (!enumerable.Any())
                throw new ArgumentNullException(nameof(addresses), "Addresses is empty");

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/wallets",
                new CreateWalletRequest(walletName, enumerable));
            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<WalletInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<WalletInfoResponse>(response);
        }

        public HdWalletInfoResponse CreateHdWallet(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string walletName, int addressCount, string password)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));
            if (addressCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(addressCount), addressCount, $"AddressCount is negative or zero");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/wallets/hd",
                new CreateHdWalletRequest(walletName, password, addressCount));
            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<HdWalletInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<HdWalletInfoResponse>(response);
        }

        public GetWalletsResponse GetWallets(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/wallets");
            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetWalletsResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetWalletsResponse>(response);
        }

        public GetHdWalletsResponse GetHdWallets(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/wallets/hd");
            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetHdWalletsResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetHdWalletsResponse>(response);
        }

        public WalletInfoResponse GetWalletInfo(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/wallets/{walletName}");
            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<WalletInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<WalletInfoResponse>(response);
        }

        public HdWalletInfoResponse GetHdWalletInfo(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/wallets/hd/{walletName}");
            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<HdWalletInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<HdWalletInfoResponse>(response);
        }

        public WalletInfoResponse AddAddress(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string walletName, IEnumerable<string> addresses)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));
            if (addresses == null)
                throw new ArgumentNullException(nameof(addresses));

            var enumerable = addresses as string[] ?? addresses.ToArray();
            if (!enumerable.Any())
                throw new ArgumentNullException(nameof(addresses), "Addresses is empty");

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/wallets/{walletName}/addresses",
                new AddAddressToWalletRequest(enumerable));
            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<WalletInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<WalletInfoResponse>(response);
        }

        public GenerateWalletAddressResponse GenerateAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/wallets/{walletName}/addresses/generate");
            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GenerateWalletAddressResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GenerateWalletAddressResponse>(response);
        }

        public HdWalletInfoResponse GenerateHdAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName,
            int addressCount, string encryptedPassword)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));
            if (addressCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(addressCount), addressCount, $"AddressCount is negative or zero");
            if (string.IsNullOrEmpty(encryptedPassword))
                throw new ArgumentNullException(nameof(encryptedPassword));

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/wallets/hd/{walletName}/addresses/generate",
                new GenerateHdWalletAddressRequest(addressCount, encryptedPassword));
            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<HdWalletInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<HdWalletInfoResponse>(response);
        }

        public RemoveAddressResponse RemoveAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName, string address)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            var request = Request.Delete($"{Consts.Blockchain}/{coin}/{network}/wallets/{walletName}/address/{address}");
            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<RemoveAddressResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<RemoveAddressResponse>(response);
        }

        public DeleteWalletResponse DeleteWallet(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));

            var request = Request.Delete($"{Consts.Blockchain}/{coin}/{network}/wallets/{walletName}");
            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<DeleteWalletResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<DeleteWalletResponse>(response);
        }

        public DeleteWalletResponse DeleteHdWallet(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            if (string.IsNullOrEmpty(walletName))
                throw new ArgumentNullException(nameof(walletName));

            var request = Request.Delete($"{Consts.Blockchain}/{coin}/{network}/wallets/hd/{walletName}");
            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<DeleteWalletResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<DeleteWalletResponse>(response);
        }
    }
}