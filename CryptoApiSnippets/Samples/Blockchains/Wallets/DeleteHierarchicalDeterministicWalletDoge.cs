using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteHierarchicalDeterministicWalletDoge(string walletName)
    {
      var coin = BtcSimilarCoin.Doge;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.DeleteHdWallet(
        coin, network, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeleteHierarchicalDeterministicWalletDoge executed successfully, " +
          $"\"{response.Payload.Message}\" status was returned"
        : $"DeleteHierarchicalDeterministicWalletDoge error: {response.ErrorMessage}");
    }
  }
}