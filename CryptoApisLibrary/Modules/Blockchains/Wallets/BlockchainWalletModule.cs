using CryptoApisLibrary.Misc;
using RestSharp;

namespace CryptoApisLibrary.Modules.Blockchains.Wallets
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