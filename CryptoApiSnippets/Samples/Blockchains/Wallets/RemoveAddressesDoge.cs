using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void RemoveAddressesDoge(string walletName, string address)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.RemoveAddress<RemoveAddressResponse>(
        NetworkCoin.DogeMainNet, walletName, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "RemoveAddressesDoge executed successfully, "
        : $"RemoveAddressesDoge error: {response.ErrorMessage}");
    }
  }
}