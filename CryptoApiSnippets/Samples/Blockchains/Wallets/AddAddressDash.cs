using CryptoApisSdkLibrary.DataTypes;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void AddAddressDash(string walletName, ICollection<string> addresses)
    {
      var coin = BtcSimilarCoin.Dash;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.AddAddress(
        coin, network, walletName, addresses);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "AddAddressDash executed successfully, " +
          $"{addresses.Count} addresses was added to \"" +
          $"{response.Wallet.Name}\" wallet"
        : $"AddAddressDash error: {response.ErrorMessage}");
    }
  }
}