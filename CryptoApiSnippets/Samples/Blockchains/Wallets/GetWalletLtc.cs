using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetWalletLtc(string walletName)
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetWalletInfo(
        coin, network, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetWalletLtc executed successfully, " +
          $"{response.Wallet.Addresses.Count} addresses of \"{response.Wallet.Name}\" wallet returned"
        : $"GetWalletLtc error: {response.ErrorMessage}");
    }
  }
}