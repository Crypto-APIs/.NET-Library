using CryptoApisSdkLibrary.Modules.Blockchains.Addresses;
using CryptoApisSdkLibrary.Modules.Blockchains.Contracts;
using CryptoApisSdkLibrary.Modules.Blockchains.Info;
using CryptoApisSdkLibrary.Modules.Blockchains.PaymentForwardings;
using CryptoApisSdkLibrary.Modules.Blockchains.Tokens;
using CryptoApisSdkLibrary.Modules.Blockchains.Transactions;
using CryptoApisSdkLibrary.Modules.Blockchains.Wallets;
using CryptoApisSdkLibrary.Modules.Blockchains.WebhookNotifications;

namespace CryptoApisSdkLibrary.Modules.Blockchains
{
    public interface IBlockchainModules
    {
        IBlockchainInfoModule Info { get; }
        IBlockchainAddressModule Address { get; }
        IBlockchainWalletModule Wallet { get; }
        IBlockchainTransactionModule Transaction { get; }
        IBlockchainPaymentForwardingModule PaymentForwarding { get; }
        IBlockchainWebhookNotificationModule WebhookNotification { get; }
        IBlockchainContractModule Contract { get; }
        IBlockchainTokenModule Token { get; }
    }
}