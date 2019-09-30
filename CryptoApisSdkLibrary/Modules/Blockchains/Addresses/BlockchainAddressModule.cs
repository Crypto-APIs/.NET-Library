using CryptoApisSdkLibrary.Misc;
using RestSharp;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Addresses
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