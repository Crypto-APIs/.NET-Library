using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetAddressInMultisignatureAddressesBch()
    {
      var coin = BtcSimilarCoin.Bch;
      var network = BtcSimilarNetwork.Testnet;
      var address = "mfX9XpSGvUSJQSL3UMgW3kqER52KWhAYM9";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GetAddressInMultisignatureAddresses(
        coin, network, address, skip: 0, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetAddressInMultisignatureAddressesBch executed successfully, " +
          $"{response.Addresses.Count} addresses returned"
        : $"GetAddressInMultisignatureAddressesBch error: {response.ErrorMessage}");
    }
  }
}