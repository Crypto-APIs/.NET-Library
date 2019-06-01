using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GenerateAccountEth()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Ropsten;
      var password = "password";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GenerateAccount(coin, network, password);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GenerateAccountEth executed successfully, " +
          $"new address is {response.Payload.Address}"
        : $"GenerateAccountEth error: {response.ErrorMessage}");
    }
  }
}