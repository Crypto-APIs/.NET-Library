using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetWalletsDash()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetWallets<GetWalletsResponse>(
        NetworkCoin.DashMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetWalletsDash executed successfully, " +
          $"{response.Wallets.Count} wallets returned"
        : $"GetWalletsDash error: {response.ErrorMessage}");
    }
  }
}