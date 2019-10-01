using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GenerateAddressesDoge(string walletName)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GenerateAddress<GenerateWalletAddressResponse>(
        NetworkCoin.DogeMainNet, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GenerateAddressesDoge executed successfully, " +
          $"{response.Payload.Wallet.Addresses.Count} addresses of \"" +
          $"{response.Payload.Wallet.Name}\" wallet returned"
        : $"GenerateAddressesDoge error: {response.ErrorMessage}");
    }
  }
}