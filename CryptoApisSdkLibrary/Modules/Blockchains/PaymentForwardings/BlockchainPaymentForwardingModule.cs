using CryptoApisSdkLibrary.Misc;
using RestSharp;

namespace CryptoApisSdkLibrary.Modules.Blockchains.PaymentForwardings
{
    internal partial class BlockchainPaymentForwardingModule : BaseModule, IBlockchainPaymentForwardingModule
    {
        public BlockchainPaymentForwardingModule(IRestClient client, CryptoApiRequest request)
            : base(client, request)
        {
            Requests = new Requests(Request);
        }

        private Requests Requests { get; }
    }
}