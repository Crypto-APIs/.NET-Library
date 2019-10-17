using CryptoApisLibrary.Misc;
using RestSharp;

namespace CryptoApisLibrary.Modules.Blockchains.Tokens
{
    internal partial class BlockchainTokenModule : BaseModule, IBlockchainTokenModule
    {
        public BlockchainTokenModule(IRestClient client, CryptoApiRequest request)
            : base(client, request)
        {
            Requests = new Requests(Request);
        }

        private Requests Requests { get; }
    }
}