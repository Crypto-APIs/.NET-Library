using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHdWalletDoge(string walletName)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetHdWalletInfo<BtcHdWalletInfoResponse>(
        NetworkCoin.DogeMainNet, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetHdWalletDoge executed successfully, " +
          $"{response.Wallet.Addresses.Count} addresses of \"" +
          $"{response.Wallet.Name}\" wallet returned"
        : $"GetHdWalletDoge error: {response.ErrorMessage}");
    }
  }
}