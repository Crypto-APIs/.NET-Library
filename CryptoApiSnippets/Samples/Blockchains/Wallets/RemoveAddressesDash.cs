using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void RemoveAddressesDash(string walletName, string address)
    {
      var coin = BtcSimilarCoin.Dash;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.RemoveAddress(
        coin, network, walletName, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "RemoveAddressesDash executed successfully, "
        : $"RemoveAddressesDash error: {response.ErrorMessage}");
    }
  }
}