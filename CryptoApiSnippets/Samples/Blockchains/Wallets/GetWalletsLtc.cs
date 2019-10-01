using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetWalletsLtc()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetWallets<GetWalletsResponse>(
        NetworkCoin.LtcMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetWalletsLtc executed successfully, " +
          $"{response.Wallets.Count} wallets returned"
        : $"GetWalletsLtc error: {response.ErrorMessage}");
    }
  }
}