using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GenerateAddressBtc()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GenerateAddress<GenerateBtcAddressResponse>(
        NetworkCoin.BtcMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GenerateAddressBtc executed successfully, " +
          $"new address is {response.Payload.Address}"
        : $"GenerateAddressBtc error: {response.ErrorMessage}");
    }
  }
}