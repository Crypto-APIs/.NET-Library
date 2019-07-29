using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public string CreatePaymentBch()
    {
      var coin = BtcSimilarCoin.Bch;
      var network = BtcSimilarNetwork.Mainnet;
      var fromAddress = "1P3t6SKHuymgrs2vvgFvtsmnKen2C8gKU9";
      var toAddress = "1K2huCLxy9tXWc5Yn8ow6vqPGvTaCXHo5q";
      var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
      var wallet = "demohdwallet";
      var password = "SECRET123456";
      var confirmations = 2;
      var fee = 0.00022827;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.CreatePayment(
        coin, network, fromAddress, toAddress, callbackUrl, wallet, 
        password, confirmations, fee);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreatePaymentBch executed successfully, PaymentId is \"" +
          $"{response.Payload.Id}\""
        : $"CreatePaymentBch error: {response.ErrorMessage}");

      return response.Payload.Id;
    }
  }
}