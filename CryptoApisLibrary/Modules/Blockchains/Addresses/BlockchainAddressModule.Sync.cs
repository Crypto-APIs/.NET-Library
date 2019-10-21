using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System.Threading;

namespace CryptoApisLibrary.Modules.Blockchains.Addresses
{
    internal partial class BlockchainAddressModule
    {
        public T GetAddress<T>(NetworkCoin networkCoin, string address)
            where T : GetAddressResponse, new()
        {
            return GetAddressAsync<T>(CancellationToken.None, networkCoin, address).GetAwaiter().GetResult();
        }

        public T GenerateAddress<T>(NetworkCoin networkCoin)
            where T : GenerateAddressResponse, new()
        {
            return GenerateAddressAsync<T>(CancellationToken.None, networkCoin).GetAwaiter().GetResult();
        }

        public T GetAddressInMultisignatureAddresses<T>(NetworkCoin networkCoin, string address, int skip = 0, int limit = 50)
            where T : GetMultisignatureAddressesResponse, new()
        {
            return GetAddressInMultisignatureAddressesAsync<T>(CancellationToken.None,
                networkCoin, address, skip, limit).GetAwaiter().GetResult();
        }

        public T GetAddressTransactions<T>(NetworkCoin networkCoin, string address, int skip = 0, int limit = 50)
            where T : GetAddressTransactionsResponse, new()
        {
            return GetAddressTransactionsAsync<T>(CancellationToken.None, networkCoin, address, skip, limit).GetAwaiter().GetResult();
        }

        public T GetNonce<T>(NetworkCoin networkCoin, string address)
            where T : GetNonceResponse, new()
        {
            return GetNonceAsync<T>(CancellationToken.None, networkCoin, address).GetAwaiter().GetResult();
        }

        public T GenerateAccount<T>(NetworkCoin networkCoin, string password)
            where T : GenerateAccountResponse, new()
        {
            return GenerateAccountAsync<T>(CancellationToken.None, networkCoin, password).GetAwaiter().GetResult();
        }
    }
}