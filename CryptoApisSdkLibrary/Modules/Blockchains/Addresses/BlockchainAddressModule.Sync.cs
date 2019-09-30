using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Diagnostics;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Addresses
{
    internal partial class BlockchainAddressModule
    {
        public GetBtcAddressResponse GetAddress(
            BtcSimilarCoin coin, BtcSimilarNetwork network, string address)
        {
            var request = Requests.GetAddress(coin, network, address);
            var result = GetSync<GetBtcAddressResponse>(request);
            if (coin != BtcSimilarCoin.Bch && result?.Payload != null)
            {
                Debug.Assert(result.Payload.Legacy == null);
            }
            return result;
        }

        public GetEthAddressResponse GetAddress(EthSimilarCoin coin, EthSimilarNetwork network, string address)
        {
            var request = Requests.GetAddress(coin, network, address);
            return GetSync<GetEthAddressResponse>(request);
        }

        public GenerateBtcAddressResponse GenerateAddress(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.GenerateAddress(coin, network);
            return GetSync<GenerateBtcAddressResponse>(request);
        }

        public GetMultisignatureAddressesResponse GetAddressInMultisignatureAddresses(
            BtcSimilarCoin coin, BtcSimilarNetwork network, string address, int skip = 0, int limit = 50)
        {
            var request = Requests.GetAddressInMultisignatureAddresses(coin, network, address, skip, limit);
            return GetSync<GetMultisignatureAddressesResponse>(request);
        }

        public GenerateEthAddressResponse GenerateAddress(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.GenerateAddress(coin, network);
            return GetSync<GenerateEthAddressResponse>(request);
        }

        public GetBtcAddressTransactionsResponse GetAddressTransactions(
            BtcSimilarCoin coin, BtcSimilarNetwork network, string address, int skip = 0, int limit = 50)
        {
            var request = Requests.GetAddressTransactions(coin, network, address, skip, limit);
            return GetSync<GetBtcAddressTransactionsResponse>(request);
        }

        public GetEthAddressTransactionsResponse GetAddressTransactions(
            EthSimilarCoin coin, EthSimilarNetwork network, string address, int skip = 0, int limit = 50)
        {
            var request = Requests.GetAddressTransactions(coin, network, address, skip, limit);
            return GetSync<GetEthAddressTransactionsResponse>(request);
        }

        public GetEthAddressBalanceResponse GetAddressBalance(EthSimilarCoin coin, EthSimilarNetwork network, string address)
        {
            var request = Requests.GetAddressBalance(coin, network, address);
            return GetSync<GetEthAddressBalanceResponse>(request);
        }

        public GenerateEthAccountResponse GenerateAccount(EthSimilarCoin coin, EthSimilarNetwork network, string password)
        {
            var request = Requests.GenerateAccount(coin, network, password);
            return GetSync<GenerateEthAccountResponse>(request);
        }
    }
}