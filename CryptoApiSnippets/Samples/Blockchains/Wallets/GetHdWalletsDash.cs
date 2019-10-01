using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHdWalletsDash()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetHdWallets<GetHdWalletsResponse>(
        NetworkCoin.DashMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetHdWalletsDash executed successfully, " +
          $"{response.Wallets.Count} HD wallets returned"
        : $"GetHdWalletsDash error: {response.ErrorMessage}");
    }
  }
}