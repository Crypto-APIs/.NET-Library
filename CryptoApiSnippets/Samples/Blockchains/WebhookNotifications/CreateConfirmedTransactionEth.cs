using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateConfirmedTransactionEth()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Ropsten;
      var url = "http://somepoint.point";
      var transactionHash = "0x87da27245076441baf7bcc6e93d328d80d11297a3a247a1ce3019168be3b7a36";
      var confirmationCount = 15;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.CreateConfirmedTransaction(
          coin, network, url, transactionHash, confirmationCount);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateConfirmedTransactionEth executed successfully, " +
          $"HookId is \"{response.Payload.Id}\""
        : $"CreateConfirmedTransactionEth error: {response.ErrorMessage}");
    }
  }
}