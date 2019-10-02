﻿using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GenerateAddressesDash(string walletName)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GenerateAddress<GenerateWalletAddressResponse>(
        NetworkCoin.DashMainNet, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GenerateAddressesDash executed successfully, " +
          $"{response.Payload.Wallet.Addresses.Count} addresses of \"" +
          $"{response.Payload.Wallet.Name}\" wallet returned"
        : $"GenerateAddressesDash error: {response.ErrorMessage}");
    }
  }
}