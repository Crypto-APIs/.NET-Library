using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteHierarchicalDeterministicWalletDash(string walletName)
    {
      var coin = BtcSimilarCoin.Dash;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.DeleteHdWallet(
        coin, network, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"DeleteHierarchicalDeterministicWalletDash executed successfully, " +
          $"\"{response.Payload.Message}\" status was returned"
        : $"DeleteHierarchicalDeterministicWalletDash error: {response.ErrorMessage}");
    }
  }
}