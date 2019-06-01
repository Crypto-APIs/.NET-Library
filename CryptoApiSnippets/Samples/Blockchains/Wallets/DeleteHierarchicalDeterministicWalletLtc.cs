using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteHierarchicalDeterministicWalletLtc(string walletName)
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.DeleteHdWallet(
        coin, network, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"DeleteHierarchicalDeterministicWalletLtc executed successfully, " +
          $"\"{response.Payload.Message}\" status was returned"
        : $"DeleteHierarchicalDeterministicWalletLtc error: {response.ErrorMessage}");
    }
  }
}