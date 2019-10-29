using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetXPubChangeAddressesDoge()
    {
      var xpub = "dgub8nixrpFXn11V8rnfHrHj9CtnUVNnvxvRcH8HFzXgp5ndWwBFrQdRhnwryvn74VHJUSj2YEvRqjGuzvoWWNByhXhCMvTGSaDnngQMXKDaiXZ";
      var startIndex = 0;
      var finishIndex = 3;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetXPubChangeAddresses<GetXPubAddressesResponse>(
        NetworkCoin.DogeMainNet, xpub, startIndex, finishIndex);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetXPubChangeAddressesDoge executed successfully, " +
          $"\"{response.Addresses.Count}\" addresses were created "
        : $"GetXPubChangeAddressesDoge error: {response.ErrorMessage}");
    }
  }
}