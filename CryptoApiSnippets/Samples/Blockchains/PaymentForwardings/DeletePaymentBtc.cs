using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeletePaymentBtc(string paymentId)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.DeletePayment<DeleteBtcPaymentResponse>(
        NetworkCoin.BtcMainNet, paymentId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeletePaymentBtc executed successfully, status is " +
          $"\"{response.Payload.Message}\""
        : $"DeletePaymentBtc error: {response.ErrorMessage}");
    }
  }
}