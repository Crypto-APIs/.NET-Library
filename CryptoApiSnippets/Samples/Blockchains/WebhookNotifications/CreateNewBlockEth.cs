using CryptoApisSdkLibrary.DataTypes;
using System;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateNewBlockEth()
    {
      var url = "http://somepoint.point";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.CreateNewBlock<EthWebHookResponse>(
        NetworkCoin.EthRopsten, url);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateNewBlockEth executed successfully, HookId is \"" +
          $"{response.Payload.Id}\""
        : $"CreateNewBlockEth error: {response.ErrorMessage}");
    }
  }
}