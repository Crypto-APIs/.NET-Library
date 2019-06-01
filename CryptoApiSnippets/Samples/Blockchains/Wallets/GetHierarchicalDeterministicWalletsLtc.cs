using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHierarchicalDeterministicWalletsLtc()
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetHdWallets(coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetHierarchicalDeterministicWalletsLtc executed successfully, " +
          $"{response.Wallets.Count} HD wallets returned"
        : $"GetHierarchicalDeterministicWalletsLtc error: {response.ErrorMessage}");
    }
  }
}