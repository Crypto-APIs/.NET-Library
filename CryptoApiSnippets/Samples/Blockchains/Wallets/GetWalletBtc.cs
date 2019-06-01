using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetWalletBtc(string walletName)
    {
      var coin = BtcSimilarCoin.Btc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetWalletInfo(
        coin, network, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetWalletBtc executed successfully, " +
          $"{response.Wallet.Addresses.Count} addresses of \"{response.Wallet.Name}\" wallet returned"
        : $"GetWalletBtc error: {response.ErrorMessage}");
    }
  }
}