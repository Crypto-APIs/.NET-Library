using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void AddAddressDash(string walletName, ICollection<string> addresses)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.AddAddress<WalletInfoResponse>(
        NetworkCoin.DashMainNet, walletName, addresses);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "AddAddressDash executed successfully, " +
          $"{addresses.Count} addresses was added to \"" +
          $"{response.Wallet.Name}\" wallet"
        : $"AddAddressDash error: {response.ErrorMessage}");
    }
  }
}