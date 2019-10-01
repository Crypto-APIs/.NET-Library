using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeletePaymentLtc(string paymentId)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.DeletePayment<DeleteBtcPaymentResponse>(
        NetworkCoin.LtcMainNet, paymentId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeletePaymentLtc executed successfully, status is " +
          $"\"{response.Payload.Message}\""
        : $"DeletePaymentLtc error: {response.ErrorMessage}");
    }
  }
}