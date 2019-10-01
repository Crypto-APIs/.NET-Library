using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void AddAddressBch(string walletName, ICollection<string> addresses)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.AddAddress<WalletInfoResponse>(
        NetworkCoin.BchMainNet, walletName, addresses);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "AddAddressBch executed successfully, " +
          $"{addresses.Count} addresses was added to \"" +
          $"{response.Wallet.Name}\" wallet"
        : $"AddAddressBch error: {response.ErrorMessage}");
    }
  }
}