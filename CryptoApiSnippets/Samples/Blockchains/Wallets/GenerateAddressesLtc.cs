using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GenerateAddressesLtc(string walletName)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GenerateAddress<GenerateWalletAddressResponse>(
        NetworkCoin. LtcMainNet, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GenerateAddressesLtc executed successfully, " +
          $"{response.Payload.Wallet.Addresses.Count} addresses of \"" +
          $"{response.Payload.Wallet.Name}\" wallet returned"
        : $"GenerateAddressesLtc error: {response.ErrorMessage}");
    }
  }
}