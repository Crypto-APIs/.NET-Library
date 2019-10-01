using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHdWalletsDoge()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetHdWallets<GetHdWalletsResponse>(
        NetworkCoin.DogeMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetHdWalletsDoge executed successfully, " +
          $"{response.Wallets.Count} HD wallets returned"
        : $"GetHdWalletsDoge error: {response.ErrorMessage}");
    }
  }
}