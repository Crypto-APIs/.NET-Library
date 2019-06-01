using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHierarchicalDeterministicWalletsBch()
    {
      var coin = BtcSimilarCoin.Bch;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetHdWallets(coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetHierarchicalDeterministicWalletsBch executed successfully, " +
          $"{response.Wallets.Count} HD wallets returned"
        : $"GetHierarchicalDeterministicWalletsBch error: {response.ErrorMessage}");
    }
  }
}