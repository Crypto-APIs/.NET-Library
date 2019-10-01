using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetWalletsBch()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetWallets<GetWalletsResponse>(
        NetworkCoin.BchMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetWalletsBch executed successfully, " +
          $"{response.Wallets.Count} wallets returned"
        : $"GetWalletsBch error: {response.ErrorMessage}");
    }
  }
}