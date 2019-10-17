using CryptoApisLibrary.Misc;
using CryptoApisLibrary.Modules.Blockchains;
using CryptoApisLibrary.Modules.Exchanges;
using RestSharp;
using System.Net;

namespace CryptoApisLibrary
{
    public class CryptoManager : ICryptoManager
    {
        public CryptoManager(string apiKey)
        {
            _client = new RestClient(Consts.Url);
            _client.AddDefaultHeader("X-API-Key", apiKey);

            var request = new CryptoApiRequest();

            _exchanges = new ExchangeModules(_client, request);
            _blockchains = new BlockchainModules(_client, request);
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

        public void SetResponseRequestLogger(IResponseRequestLogger logger)
        {
            _exchanges.SetResponseRequestLogger(logger);
            _blockchains.SetResponseRequestLogger(logger);
        }

        public IExchangeModules Exchanges => _exchanges;

        public IBlockchainModules Blockchains => _blockchains;

        private readonly IRestClient _client;
        private readonly ExchangeModules _exchanges;
        private readonly BlockchainModules _blockchains;
    }
}