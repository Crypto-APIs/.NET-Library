using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetWalletsBtc()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetWallets<GetWalletsResponse>(
        NetworkCoin.BtcMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetWalletsBtc executed successfully, " +
          $"{response.Wallets.Count} wallets returned"
        : $"GetWalletsBtc error: {response.ErrorMessage}");
    }
  }
}