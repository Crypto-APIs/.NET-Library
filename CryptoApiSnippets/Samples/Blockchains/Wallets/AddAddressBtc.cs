using CryptoApisSdkLibrary.DataTypes;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void AddAddressBtc(string walletName, IEnumerable<string> addresses)
    {
      var coin = BtcSimilarCoin.Btc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.AddAddress(
        coin, network, walletName, addresses);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"AddAddressBtc executed successfully, " +
          $"{response.Wallet.Name} addresses was added to \"{response.Wallet.Name}\" wallet"
        : $"AddAddressBtc error: {response.ErrorMessage}");
    }
  }
}