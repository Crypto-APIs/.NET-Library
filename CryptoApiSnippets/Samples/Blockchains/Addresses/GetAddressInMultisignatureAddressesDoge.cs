using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetAddressInMultisignatureAddressesDoge()
    {
      var address = "mfX9XpSGvUSJQSL3UMgW3kqER52KWhAYM9";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.
        GetAddressInMultisignatureAddresses<GetBtcMultisignatureAddressesResponse>(
          NetworkCoin.DogeTestNet, address, skip: 0, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetAddressInMultisignatureAddressesDoge executed successfully, " +
          $"{response.Addresses.Count} addresses returned"
        : $"GetAddressInMultisignatureAddressesDoge error: {response.ErrorMessage}");
    }
  }
}