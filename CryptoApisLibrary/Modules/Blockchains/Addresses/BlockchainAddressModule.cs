using CryptoApisLibrary.Misc;
using RestSharp;

namespace CryptoApisLibrary.Modules.Blockchains.Addresses
{
    internal partial class BlockchainAddressModule : BaseModule, IBlockchainAddressModule
    {
        public BlockchainAddressModule(IRestClient client, CryptoApiRequest request)
            : base(client, request)
        {
            Requests = new Requests(Request);
        }

        private Requests Requests { get; }
    }
}