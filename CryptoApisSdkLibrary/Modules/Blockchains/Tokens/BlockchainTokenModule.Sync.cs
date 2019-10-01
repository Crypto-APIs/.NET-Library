using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Tokens
{
    internal partial class BlockchainTokenModule
    {
        public T GetBalance<T>(NetworkCoin networkCoin, string address, string contract)
            where T : GetBalanceTokenResponse, new()
        {
            var request = Requests.GetBalance(networkCoin, address, contract);
            return GetSync<T>(request);
        }

        public T Transfer<T>(NetworkCoin networkCoin, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, string password, double amount)
            where T : TransferTokensResponse, new()
        {
            var request = Requests.Transfer(networkCoin, fromAddress, toAddress, contract,
                gasPrice, gasLimit, password, amount);
            return GetSync<T>(request);
        }

        public T Transfer<T>(NetworkCoin networkCoin, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, double amount, string privateKey)
            where T : TransferTokensResponse, new()
        {
            var request = Requests.Transfer(networkCoin, fromAddress, toAddress, contract,
                gasPrice, gasLimit, amount, privateKey);
            return GetSync<T>(request);
        }

        public T GetTokens<T>(NetworkCoin networkCoin, string address, int skip = 0, int limit = 50)
            where T : GetTokensResponse, new()
        {
            var request = Requests.GetTokens(networkCoin, address, skip, limit);
            return GetSync<T>(request);
        }
    }
}