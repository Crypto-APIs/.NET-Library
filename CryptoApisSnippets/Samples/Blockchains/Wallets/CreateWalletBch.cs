using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public string CreateWalletBch()
    {
      var walletName = "DemoBchWallet";
      var addresses = new[]
      {
        "1MfyBywPTSj9aAPr8cccCTcch71fd4vkDA",
        "1B5WsYR8m4axbmEMMifveDL2gtZjtpaFr5"
      };

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(
        NetworkCoin.BchMainNet, walletName, addresses);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateWalletBch executed successfully, " +
          $"wallet \"{response.Wallet.Name}\" created"
        : $"CreateWalletBch error: {response.ErrorMessage}");

      return response.Wallet.Name;
    }
  }
}