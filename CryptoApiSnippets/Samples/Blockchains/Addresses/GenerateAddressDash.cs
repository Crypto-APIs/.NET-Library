using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GenerateAddressDash()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GenerateAddress<GenerateBtcAddressResponse>(
        NetworkCoin.DashMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GenerateAddressDash executed successfully, " +
          $"new address is {response.Payload.Address}"
        : $"GenerateAddressDash error: {response.ErrorMessage}");
    }
  }
}