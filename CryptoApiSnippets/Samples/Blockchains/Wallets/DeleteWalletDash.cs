using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteWalletDash(string walletName)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.DeleteWallet<DeleteWalletResponse>(
        NetworkCoin.DashMainNet, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeleteWalletDash executed successfully, " +
          $"\"{response.Payload.Message}\" status was returned"
        : $"DeleteWalletDash error: {response.ErrorMessage}");
    }
  }
}