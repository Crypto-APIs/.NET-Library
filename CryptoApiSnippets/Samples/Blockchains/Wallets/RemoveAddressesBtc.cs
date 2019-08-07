using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void RemoveAddressesBtc(string walletName, string address)
    {
      var coin = BtcSimilarCoin.Btc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.RemoveAddress(
        coin, network, walletName, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "RemoveAddressesBtc executed successfully"
        : $"RemoveAddressesBtc error: {response.ErrorMessage}");
    }
  }
}