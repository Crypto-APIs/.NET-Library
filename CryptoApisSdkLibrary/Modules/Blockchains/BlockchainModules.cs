using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.Modules.Blockchains.Addresses;
using CryptoApisSdkLibrary.Modules.Blockchains.Contracts;
using CryptoApisSdkLibrary.Modules.Blockchains.Info;
using CryptoApisSdkLibrary.Modules.Blockchains.PaymentForwardings;
using CryptoApisSdkLibrary.Modules.Blockchains.Tokens;
using CryptoApisSdkLibrary.Modules.Blockchains.Transactions;
using CryptoApisSdkLibrary.Modules.Blockchains.Wallets;
using CryptoApisSdkLibrary.Modules.Blockchains.WebhookNotifications;
using RestSharp;

namespace CryptoApisSdkLibrary.Modules.Blockchains
{
    internal class BlockchainModules : BaseModule, IBlockchainModules
    {
        public BlockchainModules(IRestClient client, CryptoApiRequest request) : base(client, request)
        {
            Info = new BlockchainInfoModule(client, request);
            Address = new BlockchainAddressModule(client, request);
            Wallet = new BlockchainWalletModule(client, request);
            Transaction = new BlockchainTransactionModule(client, request);
            PaymentForwarding = new BlockchainPaymentForwardingModule(client, request);
            WebhookNotification = new BlockchainWebhookNotificationModule(client, request);
            Contract = new BlockchainContractModule(client, request);
            Token = new BlockchainTokenModule(client, request);
        }

        public IBlockchainInfoModule Info { get; }
        public IBlockchainAddressModule Address { get; }
        public IBlockchainWalletModule Wallet { get; }
        public IBlockchainTransactionModule Transaction { get; }
        public IBlockchainPaymentForwardingModule PaymentForwarding { get; }
        public IBlockchainWebhookNotificationModule WebhookNotification { get; }
        public IBlockchainContractModule Contract { get; }
        public IBlockchainTokenModule Token { get; }
    }
}