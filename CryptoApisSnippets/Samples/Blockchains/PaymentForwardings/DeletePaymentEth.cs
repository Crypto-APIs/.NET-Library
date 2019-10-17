using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeletePaymentEth(string paymentId)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.DeletePayment<DeleteEthPaymentResponse>(
        NetworkCoin.EthRinkeby, paymentId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeletePaymentEth executed successfully, status is " +
          $"\"{response.Payload.Message}\""
        : $"DeletePaymentEth error: {response.ErrorMessage}");
    }
  }
}