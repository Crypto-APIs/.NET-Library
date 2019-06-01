using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteWalletBch(string walletName)
    {
      var coin = BtcSimilarCoin.Bch;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.DeleteWallet(
        coin, network, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"DeleteWalletBch executed successfully, " +
          $"\"{response.Payload.Message}\" status was returned"
        : $"DeleteWalletBch error: {response.ErrorMessage}");
    }
  }
}