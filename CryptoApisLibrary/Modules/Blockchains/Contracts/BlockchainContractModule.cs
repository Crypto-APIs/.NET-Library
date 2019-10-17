using CryptoApisLibrary.Misc;
using RestSharp;

namespace CryptoApisLibrary.Modules.Blockchains.Contracts
{
    internal partial class BlockchainContractModule : BaseModule, IBlockchainContractModule
    {
        public BlockchainContractModule(IRestClient client, CryptoApiRequest request)
            : base(client, request)
        {
            Requests = new Requests(Request);
        }

        private Requests Requests { get; }
    }
}