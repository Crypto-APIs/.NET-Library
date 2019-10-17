using System.Threading;
using System.Threading.Tasks;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisLibrary.Modules.Blockchains.PaymentForwardings
{
    public interface IBlockchainPaymentForwardingModule
    {
        /// <summary>
        /// Create new payment.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="callbackUrl">Callback url addres that will be called after forwarding is processed.</param>
        /// <param name="wallet">Wallet created by current USER_ID.</param>
        /// <param name="password">Wallet password.</param>
        /// <param name="confirmations">After how many confirmations to execute the payment forwarding</param>
        /// <param name="fee">What fee should be paid for the transaction (in BTC)</param>
        T CreatePayment<T>(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string callbackUrl, string wallet, string password,
            int confirmations, double? fee = null)
            where T : CreateBtcPaymentResponse, new();

        /// <summary>
        /// Create new payment.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="callbackUrl">Callback url addres that will be called after forwarding is processed.</param>
        /// <param name="wallet">Wallet created by current USER_ID.</param>
        /// <param name="password">Wallet password.</param>
        /// <param name="confirmations">After how many confirmations to execute the payment forwarding</param>
        /// <param name="fee">What fee should be paid for the transaction (in BTC)</param>
        Task<T> CreatePaymentAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress,
            string callbackUrl, string wallet, string password, int confirmations, double? fee = null)
            where T : CreateBtcPaymentResponse, new();

        /// <summary>
        /// Create new payment using password.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="callbackUrl">Callback url addres that will be called after forwarding is processed.</param>
        /// <param name="password">Wallet password.</param>
        /// <param name="confirmations">After how many confirmations to execute the payment forwarding</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        T CreatePayment<T>(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string callbackUrl, string password,
            int confirmations, double? gasPrice = null, double? gasLimit = null)
            where T : CreateEthPaymentResponse, new();

        /// <summary>
        /// Create new payment using password.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="callbackUrl">Callback url addres that will be called after forwarding is processed.</param>
        /// <param name="password">Wallet password.</param>
        /// <param name="confirmations">After how many confirmations to execute the payment forwarding</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        Task<T> CreatePaymentAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress, string callbackUrl, string password, 
            int confirmations, double? gasPrice = null, double? gasLimit = null)
            where T : CreateEthPaymentResponse, new();

        /// <summary>
        /// Create new payment using password.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="callbackUrl">Callback url addres that will be called after forwarding is processed.</param>
        /// <param name="privateKey">Wallet private key.</param>
        /// <param name="confirmations">After how many confirmations to execute the payment forwarding</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        T CreatePaymentUsingPrivateKey<T>(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string callbackUrl, string privateKey,
            int confirmations, double? gasPrice = null, double? gasLimit = null)
            where T : CreateEthPaymentResponse, new();

        /// <summary>
        /// Create new payment using password.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="callbackUrl">Callback url addres that will be called after forwarding is processed.</param>
        /// <param name="privateKey">Wallet private key.</param>
        /// <param name="confirmations">After how many confirmations to execute the payment forwarding</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        Task<T> CreatePaymentUsingPrivateKeyAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress,
            string callbackUrl, string privateKey, int confirmations, double? gasPrice = null, double? gasLimit = null)
            where T : CreateEthPaymentResponse, new();

        /// <summary>
        /// Get detailed list of all associated payments.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        T GetPayments<T>(NetworkCoin networkCoin)
            where T : GetPaymentsResponse, new();

        /// <summary>
        /// Get detailed list of all associated payments.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        Task<T> GetPaymentsAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : GetPaymentsResponse, new();

        /// <summary>
        /// Get detailed list of the latest payments.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        T GetHistoricalPayments<T>(NetworkCoin networkCoin)
            where T : GetHistoricalPaymentsResponse, new();

        /// <summary>
        /// Get detailed list of the latest payments.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        Task<T> GetHistoricalPaymentsAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin)
            where T : GetHistoricalPaymentsResponse, new();

        /// <summary>
        /// Delete existing payment.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="paymentId">Generated UUID when payment forwarding have been created.</param>
        T DeletePayment<T>(NetworkCoin networkCoin, string paymentId)
            where T : DeletePaymentResponse, new();

        /// <summary>
        /// Delete existing payment.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="paymentId">Generated UUID when payment forwarding have been created.</param>
        Task<T> DeletePaymentAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string paymentId)
            where T : DeletePaymentResponse, new();
    }
}