using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteHierarchicalDeterministicWalletBtc(string walletName)
    {
      var coin = BtcSimilarCoin.Btc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.DeleteHdWallet(
        coin, network, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"DeleteHierarchicalDeterministicWalletBtc executed successfully, " +
          $"\"{response.Payload.Message}\" status was returned"
        : $"DeleteHierarchicalDeterministicWalletBtc error: {response.ErrorMessage}");
    }
  }
}