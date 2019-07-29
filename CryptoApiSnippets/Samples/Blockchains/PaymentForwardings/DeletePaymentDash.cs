using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeletePaymentDash(string paymentId)
    {
      var coin = BtcSimilarCoin.Dash;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.DeletePayment(
        coin, network, paymentId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeletePaymentDash executed successfully, status is \"" +
          $"{response.Payload.Message}\""
        : $"DeletePaymentDash error: {response.ErrorMessage}");
    }
  }
}