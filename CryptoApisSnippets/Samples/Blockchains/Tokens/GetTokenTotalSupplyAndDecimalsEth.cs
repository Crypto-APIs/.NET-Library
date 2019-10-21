using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetTokenTotalSupplyAndDecimalsEth()
    {
      var contract = "0xe9fa3d69c35b907e57f6561c1daf9bf7fc5d3786 ";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Token.GetTokenTotalSupplyAndDecimals<GetTokenTotalSupplyAndDecimalsResponse>(
        NetworkCoin.EthMainNet, contract);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetTokenTotalSupplyAndDecimalsEth executed successfully, " +
          $"TotalSupply is \"{response.Payload.TotalSupply}\""
        : $"GetTokenTotalSupplyAndDecimalsEth error: {response.ErrorMessage}");
    }
  }
}