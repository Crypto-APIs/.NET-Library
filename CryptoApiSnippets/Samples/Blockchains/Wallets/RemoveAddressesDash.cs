using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void RemoveAddressesDash(string walletName, string address)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.RemoveAddress<RemoveAddressResponse>(
        NetworkCoin.DashMainNet, walletName, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "RemoveAddressesDash executed successfully, "
        : $"RemoveAddressesDash error: {response.ErrorMessage}");
    }
  }
}