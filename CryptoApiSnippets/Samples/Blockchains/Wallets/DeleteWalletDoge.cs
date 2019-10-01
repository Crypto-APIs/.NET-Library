using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteWalletDoge(string walletName)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.DeleteWallet<DeleteWalletResponse>(
        NetworkCoin.DogeMainNet, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeleteWalletDoge executed successfully, " +
          $"\"{response.Payload.Message}\" status was returned"
        : $"DeleteWalletDoge error: {response.ErrorMessage}");
    }
  }
}