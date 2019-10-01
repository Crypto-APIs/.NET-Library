using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void RemoveAddressesBch(string walletName, string address)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.RemoveAddress<RemoveAddressResponse>(
        NetworkCoin.BchMainNet, walletName, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "RemoveAddressesBch executed successfully, "
        : $"RemoveAddressesBch error: {response.ErrorMessage}");
    }
  }
}