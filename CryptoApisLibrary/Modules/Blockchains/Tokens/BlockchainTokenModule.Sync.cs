using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System.Threading;

namespace CryptoApisLibrary.Modules.Blockchains.Tokens
{
    internal partial class BlockchainTokenModule
    {
        public T GetBalance<T>(NetworkCoin networkCoin, string address, string contract)
            where T : GetBalanceTokenResponse, new()
        {
            return GetBalanceAsync<T>(CancellationToken.None, networkCoin, address, contract).GetAwaiter().GetResult();
        }

        public T Transfer<T>(NetworkCoin networkCoin, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, string password, double amount)
            where T : TransferTokensResponse, new()
        {
            return TransferAsync<T>(CancellationToken.None, networkCoin, fromAddress, toAddress, contract,
                gasPrice, gasLimit, password, amount).GetAwaiter().GetResult();
        }

        public T Transfer<T>(NetworkCoin networkCoin, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, double amount, string privateKey)
            where T : TransferTokensResponse, new()
        {
            return TransferAsync<T>(CancellationToken.None, networkCoin, fromAddress, toAddress, contract,
                gasPrice, gasLimit, amount, privateKey).GetAwaiter().GetResult();
        }

        public T GetTokens<T>(NetworkCoin networkCoin, string address, int skip = 0, int limit = 50)
            where T : GetEthTokensResponse, new()
        {
            return GetTokensAsync<T>(CancellationToken.None, networkCoin, address, skip, limit).GetAwaiter().GetResult();
        }

        public T GetTransactions<T>(NetworkCoin networkCoin, string address, int skip = 0, int limit = 50) 
            where T : GetEthTransactionsResponse, new()
        {
            return GetTransactionsAsync<T>(CancellationToken.None, networkCoin, address, skip, limit).GetAwaiter().GetResult();
        }

        public T GetTokenTotalSupplyAndDecimals<T>(NetworkCoin networkCoin, string contract) 
            where T : GetTokenTotalSupplyAndDecimalsResponse, new()
        {
            return GetTokenTotalSupplyAndDecimalsAsync<T>(
                CancellationToken.None, networkCoin, contract).GetAwaiter().GetResult();
        }
    }
}