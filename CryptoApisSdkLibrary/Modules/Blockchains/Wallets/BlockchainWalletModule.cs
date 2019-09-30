using CryptoApisSdkLibrary.Misc;
using RestSharp;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Wallets
{
    internal partial class BlockchainWalletModule : BaseModule, IBlockchainWalletModule
    {
        public BlockchainWalletModule(IRestClient client, CryptoApiRequest request)
            : base(client, request)
        {
            Requests = new Requests(Request);
        }

        private Requests Requests { get; }
    }
}