using CryptoApisSdkLibrary.DataTypes;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void AddAddressLtc(string walletName, IEnumerable<string> addresses)
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.AddAddress(
        coin, network, walletName, addresses);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"AddAddressLtc executed successfully, " +
          $"{response.Wallet.Name} addresses was added to \"{response.Wallet.Name}\" wallet"
        : $"AddAddressLtc error: {response.ErrorMessage}");
    }
  }
}