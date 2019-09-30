using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Tokens
{
    internal partial class BlockchainTokenModule
    {
        public GetBalanceTokenResponse GetBalance(EthSimilarCoin coin, EthSimilarNetwork network, string address, string contract)
        {
            var request = Requests.GetBalance(coin, network, address, contract);
            return GetSync<GetBalanceTokenResponse>(request);
        }

        public TransferTokensResponse Transfer(EthSimilarCoin coin, EthSimilarNetwork network, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, string password, double amount)
        {
            var request = Requests.Transfer(coin, network, fromAddress, toAddress, contract,
                gasPrice, gasLimit, password, amount);
            return GetSync<TransferTokensResponse>(request);
        }

        public TransferTokensResponse Transfer(EthSimilarCoin coin, EthSimilarNetwork network, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, double amount, string privateKey)
        {
            var request = Requests.Transfer(coin, network, fromAddress, toAddress, contract,
                gasPrice, gasLimit, amount, privateKey);
            return GetSync<TransferTokensResponse>(request);
        }

        public GetTokensResponse GetTokens(EthSimilarCoin coin, EthSimilarNetwork network, string address, int skip = 0, int limit = 50)
        {
            var request = Requests.GetTokens(coin, network, address, skip, limit);
            return GetSync<GetTokensResponse>(request);
        }
    }
}