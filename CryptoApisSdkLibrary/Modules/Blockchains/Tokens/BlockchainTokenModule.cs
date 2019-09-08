using CryptoApisSdkLibrary.Misc;
using RestSharp;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Tokens
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