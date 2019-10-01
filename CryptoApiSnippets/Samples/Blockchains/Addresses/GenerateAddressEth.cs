using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GenerateAddressEth()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GenerateAddress<GenerateEthAddressResponse>(
        NetworkCoin.EthRopsten);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GenerateAddressEth executed successfully, " +
          $"new address is {response.Payload.Address}"
        : $"GenerateAddressEth error: {response.ErrorMessage}");
    }
  }
}