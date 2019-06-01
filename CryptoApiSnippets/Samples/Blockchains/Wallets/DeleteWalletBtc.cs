using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteWalletBtc(string walletName)
    {
      var coin = BtcSimilarCoin.Btc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.DeleteWallet(
        coin, network, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"DeleteWalletBtc executed successfully, " +
          $"\"{response.Payload.Message}\" status was returned"
        : $"DeleteWalletBtc error: {response.ErrorMessage}");
    }
  }
}