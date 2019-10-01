using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeletePaymentDash(string paymentId)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.DeletePayment<DeleteBtcPaymentResponse>(
        NetworkCoin.DashMainNet, paymentId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeletePaymentDash executed successfully, status is " +
          $"\"{response.Payload.Message}\""
        : $"DeletePaymentDash error: {response.ErrorMessage}");
    }
  }
}