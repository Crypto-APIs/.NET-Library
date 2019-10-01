using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHdWalletsBtc()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetHdWallets<GetHdWalletsResponse>(
        NetworkCoin.BtcMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetHdWalletsBtc executed successfully, " +
          $"{response.Wallets.Count} HD wallets returned"
        : $"GetHdWalletsBtc error: {response.ErrorMessage}");
    }
  }
}