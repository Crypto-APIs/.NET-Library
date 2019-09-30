using CryptoApisSdkLibrary.Misc;
using RestSharp;

namespace CryptoApisSdkLibrary.Modules.Blockchains.WebhookNotifications
{
    internal partial class BlockchainWebhookNotificationModule : BaseModule, IBlockchainWebhookNotificationModule
    {
        public BlockchainWebhookNotificationModule(IRestClient client, CryptoApiRequest request)
            : base(client, request)
        {
            Requests = new Requests(Request);
        }

        private Requests Requests { get; }
    }
}