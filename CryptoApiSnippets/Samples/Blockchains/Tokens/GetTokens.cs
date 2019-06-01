using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetTokens()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Rinkeby;
      var address = "0x2b5634c42055806a59e9107ed44d43c426e58258";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Token.GetTokens(coin, network, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetTokens executed successfully, " +
          $"{response.Tokens.Count} tokens returned"
        : $"GetTokens error: {response.ErrorMessage}");
    }
  }
}