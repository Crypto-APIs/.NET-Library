using CryptoApisLibrary.Misc;
using RestSharp;

namespace CryptoApisLibrary.Modules.Blockchains.Info
{
    internal partial class BlockchainInfoModule : BaseModule, IBlockchainInfoModule
    {
        public BlockchainInfoModule(IRestClient client, CryptoApiRequest request)
            : base(client, request)
        {
            Requests = new Requests(Request);
        }

        private Requests Requests { get; }
    }
}