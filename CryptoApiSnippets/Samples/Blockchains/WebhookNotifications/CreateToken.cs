using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateToken()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Ropsten;
      var url = "http://somepoint.point";
      var address = "0xe816c453a99b12bb65ea55db22a6fe70f63c2c7a";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.CreateToken(
          coin, network, url, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"CreateToken executed successfully, HookId is \"{response.Payload.Id}\""
        : $"CreateToken error: {response.ErrorMessage}");
    }
  }
}