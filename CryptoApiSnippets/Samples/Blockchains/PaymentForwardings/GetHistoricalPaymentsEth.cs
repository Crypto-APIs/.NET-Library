using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHistoricalPaymentsEth()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Ropsten;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.GetHistoricalPayments(
        coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetHistoricalPaymentsEth executed successfully, " +
          $"{response.Payments.Count} payments returned"
        : $"GetHistoricalPaymentsEth error: {response.ErrorMessage}");
    }
  }
}