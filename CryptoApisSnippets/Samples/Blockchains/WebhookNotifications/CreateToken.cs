using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateToken()
    {
      var url = "http://somepoint.point";
      var address = "0xe816c453a99b12bb65ea55db22a6fe70f63c2c7a";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.CreateToken<CreateEthAddressWebHookResponse>(
          NetworkCoin.EthRopsten, url, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"CreateToken executed successfully, HookId is \"{response.Hook.Id}\""
        : $"CreateToken error: {response.ErrorMessage}");
    }
  }
}