using CryptoApisLibrary.Modules.Blockchains.Addresses;
using CryptoApisLibrary.Modules.Blockchains.Contracts;
using CryptoApisLibrary.Modules.Blockchains.Info;
using CryptoApisLibrary.Modules.Blockchains.PaymentForwardings;
using CryptoApisLibrary.Modules.Blockchains.Tokens;
using CryptoApisLibrary.Modules.Blockchains.Transactions;
using CryptoApisLibrary.Modules.Blockchains.Wallets;
using CryptoApisLibrary.Modules.Blockchains.WebhookNotifications;

namespace CryptoApisLibrary.Modules.Blockchains
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