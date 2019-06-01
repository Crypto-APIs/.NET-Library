using CryptoApisSdkLibrary.Misc;
using RestSharp;

namespace CryptoApisSdkLibrary.Modules
{
    internal class BlockchainModule : BaseModule, IBlockchainModule
    {
        public BlockchainModule(IRestClient client, CryptoApiRequest request) : base(client, request)
        {
        }
    }
}