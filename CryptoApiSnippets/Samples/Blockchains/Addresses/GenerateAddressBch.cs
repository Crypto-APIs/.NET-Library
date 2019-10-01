using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GenerateAddressBch()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GenerateAddress<GenerateBtcAddressResponse>(
        NetworkCoin.BchMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GenerateAddressBch executed successfully, " +
          $"new address is {response.Payload.Address}"
        : $"GenerateAddressBch error: {response.ErrorMessage}");
    }
  }
}