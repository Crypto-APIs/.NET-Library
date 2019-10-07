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
    internal class BlockchainModules : IBlockchainModules
    {
        public BlockchainModules(IRestClient client, CryptoApiRequest request)
        {
            _info = new BlockchainInfoModule(client, request);
            _address = new BlockchainAddressModule(client, request);
            _wallet = new BlockchainWalletModule(client, request);
            _transaction = new BlockchainTransactionModule(client, request);
            _paymentForwarding = new BlockchainPaymentForwardingModule(client, request);
            _webhookNotification = new BlockchainWebhookNotificationModule(client, request);
            _contract = new BlockchainContractModule(client, request);
            _token = new BlockchainTokenModule(client, request);
        }

        public IBlockchainInfoModule Info => _info;
        public IBlockchainAddressModule Address => _address;
        public IBlockchainWalletModule Wallet => _wallet;
        public IBlockchainTransactionModule Transaction => _transaction;
        public IBlockchainPaymentForwardingModule PaymentForwarding => _paymentForwarding;
        public IBlockchainWebhookNotificationModule WebhookNotification => _webhookNotification;
        public IBlockchainContractModule Contract => _contract;
        public IBlockchainTokenModule Token => _token;

        public void SetResponseRequestLogger(IResponseRequestLogger logger)
        {
            _info.SetResponseRequestLogger(logger);
            _address.SetResponseRequestLogger(logger);
            _wallet.SetResponseRequestLogger(logger);
            _transaction.SetResponseRequestLogger(logger);
            _paymentForwarding.SetResponseRequestLogger(logger);
            _webhookNotification.SetResponseRequestLogger(logger);
            _contract.SetResponseRequestLogger(logger);
            _token.SetResponseRequestLogger(logger);
        }

        private readonly BlockchainInfoModule _info;
        private readonly BlockchainAddressModule _address;
        private readonly BlockchainWalletModule _wallet;
        private readonly BlockchainTransactionModule _transaction;
        private readonly BlockchainPaymentForwardingModule _paymentForwarding;
        private readonly BlockchainWebhookNotificationModule _webhookNotification;
        private readonly BlockchainContractModule _contract;
        private readonly BlockchainTokenModule _token;
    }
}