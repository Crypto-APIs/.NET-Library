using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void RemoveAddressesBch(string walletName, string address)
    {
      var coin = BtcSimilarCoin.Bch;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.RemoveAddress(
        coin, network, walletName, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"RemoveAddressesBch executed successfully, "
        : $"RemoveAddressesBch error: {response.ErrorMessage}");
    }
  }
}