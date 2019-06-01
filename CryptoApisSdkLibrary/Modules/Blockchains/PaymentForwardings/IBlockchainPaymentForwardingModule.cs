﻿using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSdkLibrary.Modules.Blockchains.PaymentForwardings
{
    public interface IBlockchainPaymentForwardingModule
    {
        /// <summary>
        /// Create new payment.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="callbackUrl">Callback url addres that will be called after forwarding is processed.</param>
        /// <param name="wallet">Wallet created by current USER_ID.</param>
        /// <param name="password">Wallet password.</param>
        /// <param name="confirmations">After how many confirmations to execute the payment forwarding</param>
        /// <param name="fee">What fee should be paid for the transaction (in BTC)</param>
        CreateBtcPaymentResponse CreatePayment(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string fromAddress, string toAddress, string callbackUrl, string wallet, string password,
            int confirmations, double? fee = null);

        /// <summary>
        /// Create new payment using password.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="callbackUrl">Callback url addres that will be called after forwarding is processed.</param>
        /// <param name="password">Wallet password.</param>
        /// <param name="confirmations">After how many confirmations to execute the payment forwarding</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        CreateEthPaymentResponse CreatePayment(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string callbackUrl, string password,
            int confirmations, double? gasPrice = null, double? gasLimit = null);

        /// <summary>
        /// Create new payment using password.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="callbackUrl">Callback url addres that will be called after forwarding is processed.</param>
        /// <param name="privateKey">Wallet private key.</param>
        /// <param name="confirmations">After how many confirmations to execute the payment forwarding</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        CreateEthPaymentResponse CreatePaymentUsingPrivateKey(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string callbackUrl, string privateKey,
            int confirmations, double? gasPrice = null, double? gasLimit = null);

        /// <summary>
        /// Get detailed list of all associated payments.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        GetBtcPaymentsResponse GetPayments(BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// Get detailed list of all associated payments.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        GetEthPaymentsResponse GetPayments(EthSimilarCoin coin, EthSimilarNetwork network);

        /// <summary>
        /// Get detailed list of the latest payments.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        GetBtcHistoricalPaymentsResponse GetHistoricalPayments(BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// Get detailed list of the latest payments.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        GetEthHistoricalPaymentsResponse GetHistoricalPayments(EthSimilarCoin coin, EthSimilarNetwork network);

        /// <summary>
        /// Delete existing payment.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="paymentId">Generated UUID when payment forwarding have been created.</param>
        DeleteBtcPaymentResponse DeletePayment(BtcSimilarCoin coin, BtcSimilarNetwork network, string paymentId);

        /// <summary>
        /// Delete existing payment.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="paymentId">Generated UUID when payment forwarding have been created.</param>
        DeleteEthPaymentResponse DeletePayment(EthSimilarCoin coin, EthSimilarNetwork network, string paymentId);
    }
}