using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public string CreateWalletLtc()
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;
      var walletName = "DemoLtcWallet";
      var addresses = new[]
      {
        "LdYmBLEYNHs4XDomUwCHAQi2RNZ61dvu9n",
        "LUc2pToUCLLGh3PdfMQonHQhFrQmFDwRwM"
      };

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.CreateWallet(
        coin, network, walletName, addresses);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateWalletLtc executed successfully, " +
          $"wallet \"{response.Wallet.Name}\" created"
        : $"CreateWalletLtc error: {response.ErrorMessage}");

      return response.Wallet.Name;
    }
  }
}