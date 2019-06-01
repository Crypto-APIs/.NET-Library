using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public string CreatePaymentLtc()
    {
      var coin = BtcSimilarCoin.Btc;
      var network = BtcSimilarNetwork.Mainnet;
      var fromAddress = "LNBscCs43tU61X1NmoqGySPyRBpoFMwwvy";
      var toAddress = "LXAWGfYhFEqfW8oTQ9Ebj7yX4qP6gK1b4K";
      var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
      var wallet = "demohdwallet";
      var password = "SECRET123456";
      var confirmations = 2;
      var fee = 0.00022827;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.CreatePayment(
        coin, network, fromAddress, toAddress, callbackUrl, wallet, password, confirmations, fee);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"CreatePaymentLtc executed successfully, PaymentId is \"{response.Payload.Id}\""
        : $"CreatePaymentLtc error: {response.ErrorMessage}");

      return response.Payload.Id;
    }
  }
}