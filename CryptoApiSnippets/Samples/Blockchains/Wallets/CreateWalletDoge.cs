using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public string CreateWalletDoge()
    {
      var coin = BtcSimilarCoin.Doge;
      var network = BtcSimilarNetwork.Mainnet;
      var walletName = "DemoDogeWallet";
      var addresses = new[]
      {
        "1MfyBywPTSj9aAPr8cccCTcch71fd4vkDA",
        "1B5WsYR8m4axbmEMMifveDL2gtZjtpaFr5"
      };

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.CreateWallet(
        coin, network, walletName, addresses);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateWalletDoge executed successfully, " +
          $"wallet \"{response.Wallet.Name}\" created"
        : $"CreateWalletDoge error: {response.ErrorMessage}");

      return response.Wallet.Name;
    }
  }
}