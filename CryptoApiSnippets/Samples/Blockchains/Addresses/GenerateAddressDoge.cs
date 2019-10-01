using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GenerateAddressDoge()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GenerateAddress<GenerateBtcAddressResponse>(
        NetworkCoin.DogeMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GenerateAddressDoge executed successfully, " +
          $"new address is {response.Payload.Address}"
        : $"GenerateAddressDoge error: {response.ErrorMessage}");
    }
  }
}