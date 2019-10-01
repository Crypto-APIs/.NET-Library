using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Addresses
{
    internal partial class BlockchainAddressModule
    {
        public T GetAddress<T>(NetworkCoin networkCoin, string address) 
            where T : GetAddressResponse, new()
        {
            var request = Requests.GetAddress(networkCoin, address);
            return GetSync<T>(request);
        }

        public T GenerateAddress<T>(NetworkCoin networkCoin)
            where T : GenerateAddressResponse, new()
        {
            var request = Requests.GenerateAddress(networkCoin);
            return GetSync<T>(request);
        }

        public T GetAddressInMultisignatureAddresses<T>(NetworkCoin networkCoin, string address, int skip = 0, int limit = 50)
            where T : GetMultisignatureAddressesResponse, new()
        {
            var request = Requests.GetAddressInMultisignatureAddresses(networkCoin, address, skip, limit);
            return GetSync<T>(request);
        }

        public T GetAddressTransactions<T>(NetworkCoin networkCoin, string address, int skip = 0, int limit = 50)
            where T : GetAddressTransactionsResponse, new()
        {
            var request = Requests.GetAddressTransactions(networkCoin, address, skip, limit);
            return GetSync<T>(request);
        }

        public T GetAddressBalance<T>(NetworkCoin networkCoin, string address)
            where T : GetAddressBalanceResponse, new()
        {
            var request = Requests.GetAddressBalance(networkCoin, address);
            return GetSync<T>(request);
        }

        public T GenerateAccount<T>(NetworkCoin networkCoin, string password)
            where T : GenerateAccountResponse, new()
        {
            var request = Requests.GenerateAccount(networkCoin, password);
            return GetSync<T>(request);
        }
    }
}