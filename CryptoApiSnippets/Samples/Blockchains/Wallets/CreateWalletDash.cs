using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public string CreateWalletDash()
    {
      var walletName = "DemoDashWallet";
      var addresses = new[]
      {
        "1MfyBywPTSj9aAPr8cccCTcch71fd4vkDA",
        "1B5WsYR8m4axbmEMMifveDL2gtZjtpaFr5"
      };

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(
        NetworkCoin.DashMainNet, walletName, addresses);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateWalletDash executed successfully, " +
          $"wallet \"{response.Wallet.Name}\" created"
        : $"CreateWalletDash error: {response.ErrorMessage}");

      return response.Wallet.Name;
    }
  }
}