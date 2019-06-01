using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHierarchicalDeterministicWalletLtc(string walletName)
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetHdWalletInfo(
        coin, network, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetHierarchicalDeterministicWalletLtc executed successfully, " +
          $"{response.Wallet.Addresses.Count} addresses of \"{response.Wallet.Name}\" wallet returned"
        : $"GetHierarchicalDeterministicWalletLtc error: {response.ErrorMessage}");
    }
  }
}