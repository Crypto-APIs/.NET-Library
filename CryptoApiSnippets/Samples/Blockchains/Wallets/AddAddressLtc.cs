using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void AddAddressLtc(string walletName, ICollection<string> addresses)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.AddAddress<WalletInfoResponse>(
        NetworkCoin.LtcMainNet, walletName, addresses);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "AddAddressLtc executed successfully, " +
          $"{response.Wallet.Name} addresses was added to \"" +
          $"{response.Wallet.Name}\" wallet"
        : $"AddAddressLtc error: {response.ErrorMessage}");
    }
  }
}