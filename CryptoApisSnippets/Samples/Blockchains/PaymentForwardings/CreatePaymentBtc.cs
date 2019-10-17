using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public string CreatePaymentBtc()
    {
      var fromAddress = "1P3t6SKHuymgrs2vvgFvtsmnKen2C8gKU9";
      var toAddress = "1K2huCLxy9tXWc5Yn8ow6vqPGvTaCXHo5q";
      var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
      var wallet = "demohdwallet";
      var password = "SECRET123456";
      var confirmations = 2;
      var fee = 0.00022827;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
        NetworkCoin.BtcMainNet, fromAddress, toAddress, callbackUrl, wallet, 
        password, confirmations, fee);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreatePaymentBtc executed successfully, PaymentId is \"" +
          $"{response.Payload.Id}\""
        : $"CreatePaymentBtc error: {response.ErrorMessage}");

      return response.Payload.Id;
    }
  }
}