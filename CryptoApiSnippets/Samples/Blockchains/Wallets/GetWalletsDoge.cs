using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetWalletsDoge()
    {
      var coin = BtcSimilarCoin.Doge;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetWallets(coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetWalletsDoge executed successfully, " +
          $"{response.Wallets.Count} wallets returned"
        : $"GetWalletsDoge error: {response.ErrorMessage}");
    }
  }
}