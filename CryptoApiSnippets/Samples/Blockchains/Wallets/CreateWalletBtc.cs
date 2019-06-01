using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public string CreateWalletBtc()
    {
      var coin = BtcSimilarCoin.Btc;
      var network = BtcSimilarNetwork.Mainnet;
      var walletName = "DemoBtcWallet";
      var addresses = new[]
      {
        "1MfyBywPTSj9aAPr8cccCTcch71fd4vkDA",
        "1B5WsYR8m4axbmEMMifveDL2gtZjtpaFr5"
      };

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.CreateWallet(
        coin, network, walletName, addresses);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"CreateWalletBtc executed successfully, " +
          $"wallet \"{response.Wallet.Name}\" created"
        : $"CreateWalletBtc error: {response.ErrorMessage}");

      return response.Wallet.Name;
    }
  }
}