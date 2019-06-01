using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteHierarchicalDeterministicWalletBch(string walletName)
    {
      var coin = BtcSimilarCoin.Bch;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.DeleteHdWallet(
        coin, network, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"DeleteHierarchicalDeterministicWalletBch executed successfully, " +
          $"\"{response.Payload.Message}\" status was returned"
        : $"DeleteHierarchicalDeterministicWalletBch error: {response.ErrorMessage}");
    }
  }
}