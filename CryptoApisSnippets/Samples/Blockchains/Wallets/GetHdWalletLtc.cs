using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHdWalletLtc(string walletName)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetHdWalletInfo<BtcHdWalletInfoResponse>(
        NetworkCoin.LtcMainNet, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetHdWalletLtc executed successfully, " +
          $"{response.Wallet.Addresses.Count} addresses of \"" +
          $"{response.Wallet.Name}\" wallet returned"
        : $"GetHdWalletLtc error: {response.ErrorMessage}");
    }
  }
}