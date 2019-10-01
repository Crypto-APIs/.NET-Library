using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetPaymentsEth()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.
        GetPayments<GetEthPaymentsResponse>(NetworkCoin.EthRopsten);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetPaymentsEth executed successfully, " +
          $"{response.Payments.Count} payments returned"
        : $"GetPaymentsEth error: {response.ErrorMessage}");
    }
  }
}