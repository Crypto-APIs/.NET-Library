using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHistoricalPaymentsEth()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.
        GetHistoricalPayments<GetEthHistoricalPaymentsResponse>(
          NetworkCoin.EthRopsten);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetHistoricalPaymentsEth executed successfully, " +
          $"{response.Payments.Count} payments returned"
        : $"GetHistoricalPaymentsEth error: {response.ErrorMessage}");
    }
  }
}