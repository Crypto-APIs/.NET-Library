using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetAddressInMultisignatureAddressesLtc()
    {
      var address = "mfX9XpSGvUSJQSL3UMgW3kqER52KWhAYM9";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.
        GetAddressInMultisignatureAddresses<GetBtcMultisignatureAddressesResponse>(
          NetworkCoin.LtcTestNet, address, skip: 0, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetAddressInMultisignatureAddressesLtc executed successfully, " +
          $"{response.Addresses.Count} addresses returned"
        : $"GetAddressInMultisignatureAddressesLtc error: {response.ErrorMessage}");
    }
  }
}