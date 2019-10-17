using CryptoApisLibrary.Misc;
using RestSharp;

namespace CryptoApisLibrary.Modules.Blockchains.Transactions
{
    internal partial class BlockchainTransactionModule : BaseModule, IBlockchainTransactionModule
    {
        public BlockchainTransactionModule(IRestClient client, CryptoApiRequest request)
            : base(client, request)
        {
            Requests = new Requests(Request);
        }

        private Requests Requests { get; }
    }
}