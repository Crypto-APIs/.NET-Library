using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHdWalletBch(string walletName)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetHdWalletInfo<BchHdWalletInfoResponse>(
        NetworkCoin.BchMainNet, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetHdWalletBch executed successfully, " +
          $"{response.Wallet.Addresses.Count} addresses of \"" +
          $"{response.Wallet.Name}\" wallet returned"
        : $"GetHdWalletBch error: {response.ErrorMessage}");
    }
  }
}