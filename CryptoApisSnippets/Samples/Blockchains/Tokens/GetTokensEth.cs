using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetTokensEth()
    {
      var address = "0x2b5634c42055806a59e9107ed44d43c426e58258";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Token.GetTokens<GetEthTokensResponse>(
        NetworkCoin.EthRinkeby, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetTokensEth executed successfully, " +
          $"{response.Tokens.Count} tokens returned"
        : $"GetTokensEth error: {response.ErrorMessage}");
    }
  }
}