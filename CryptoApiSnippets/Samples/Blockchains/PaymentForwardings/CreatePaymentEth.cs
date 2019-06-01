using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public string CreatePaymentEth()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Rinkeby;
      var fromAddress = "0x195831d0fa4888c3fd577110d23ee464265c551a";
      var toAddress = "0x12b1883c01377f45ee5d7448a32b5ac1709af076";
      var callbackUrl = "http://somepoint.point";
      var password = "123456";
      var confirmations = 2;
      var gasPrice = 5000000000;
      var gasLimit = 21000;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.CreatePayment(
        coin, network, fromAddress, toAddress, callbackUrl, password, confirmations, gasPrice, gasLimit);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"CreatePaymentEth executed successfully, PaymentId is \"{response.Payload.Id}\""
        : $"CreatePaymentEth error: {response.ErrorMessage}");

      return response.Payload.Id;
    }
  }
}