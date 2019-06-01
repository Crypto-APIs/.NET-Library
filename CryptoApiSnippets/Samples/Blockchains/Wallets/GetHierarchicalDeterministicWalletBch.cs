using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHierarchicalDeterministicWalletBch(string walletName)
    {
      var coin = BtcSimilarCoin.Bch;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetHdWalletInfo(
        coin, network, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetHierarchicalDeterministicWalletBch executed successfully, " +
          $"{response.Wallet.Addresses.Count} addresses of \"{response.Wallet.Name}\" wallet returned"
        : $"GetHierarchicalDeterministicWalletBch error: {response.ErrorMessage}");
    }
  }
}