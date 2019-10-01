using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void AddAddressBtc(string walletName, ICollection<string> addresses)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.AddAddress<WalletInfoResponse>(
        NetworkCoin.BtcMainNet, walletName, addresses);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "AddAddressBtc executed successfully, " +
          $"{addresses.Count} addresses was added to \"" +
          $"{response.Wallet.Name}\" wallet"
        : $"AddAddressBtc error: {response.ErrorMessage}");
    }
  }
}