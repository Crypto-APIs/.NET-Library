using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteWalletBch(string walletName)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.DeleteWallet<DeleteWalletResponse>(
        NetworkCoin.BchMainNet, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeleteWalletBch executed successfully, " +
          $"\"{response.Payload.Message}\" status was returned"
        : $"DeleteWalletBch error: {response.ErrorMessage}");
    }
  }
}