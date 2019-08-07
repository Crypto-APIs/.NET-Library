using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeletePaymentDoge(string paymentId)
    {
      var coin = BtcSimilarCoin.Doge;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.DeletePayment(
        coin, network, paymentId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeletePaymentDoge executed successfully, status is " +
          $"\"{response.Payload.Message}\""
        : $"DeletePaymentDoge error: {response.ErrorMessage}");
    }
  }
}