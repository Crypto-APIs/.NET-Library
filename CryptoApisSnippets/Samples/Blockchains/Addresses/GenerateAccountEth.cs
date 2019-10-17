using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GenerateAccountEth()
    {
      var password = "password";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GenerateAccount<GenerateEthAccountResponse>(
        NetworkCoin.EthRopsten, password);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GenerateAccountEth executed successfully, " +
          $"new address is {response.Payload.Address}"
        : $"GenerateAccountEth error: {response.ErrorMessage}");
    }
  }
}