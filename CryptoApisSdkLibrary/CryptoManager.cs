using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.Modules.Blockchains;
using CryptoApisSdkLibrary.Modules.Exchanges;
using RestSharp;
using System.Net;

namespace CryptoApisSdkLibrary
{
    public class CryptoManager : ICryptoManager
    {
        public CryptoManager(string apiKey)
        {
            _client = new RestClient(Consts.Url);
            _client.AddDefaultHeader("X-API-Key", apiKey);

            var request = new CryptoApiRequest();

            Exchanges = new ExchangeModules(_client, request);
            Blockchains = new BlockchainModules(_client, request);
        }

        public CryptoManager(string apiKey, ProxyCredentials credentials) : this(apiKey)
        {
            if (credentials != null)
            {
                _client.Proxy = MakeProxy(credentials);
            }
        }

        private IWebProxy MakeProxy(ProxyCredentials credentials)
        {
            return new WebProxy($"{credentials.Host}:{credentials.Port}")
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(credentials.Username, credentials.Password, credentials.Domain)
            };
        }

        public IExchangeModules Exchanges { get; }
        public IBlockchainModules Blockchains { get; }

        private readonly IRestClient _client;
    }
}