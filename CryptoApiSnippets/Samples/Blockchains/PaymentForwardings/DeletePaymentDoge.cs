using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeletePaymentDoge(string paymentId)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.DeletePayment<DeleteBtcPaymentResponse>(
        NetworkCoin.DogeMainNet, paymentId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeletePaymentDoge executed successfully, status is " +
          $"\"{response.Payload.Message}\""
        : $"DeletePaymentDoge error: {response.ErrorMessage}");
    }
  }
}