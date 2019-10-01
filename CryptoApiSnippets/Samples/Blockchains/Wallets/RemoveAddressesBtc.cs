using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void RemoveAddressesBtc(string walletName, string address)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.RemoveAddress<RemoveAddressResponse>(
        NetworkCoin.BtcMainNet, walletName, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "RemoveAddressesBtc executed successfully"
        : $"RemoveAddressesBtc error: {response.ErrorMessage}");
    }
  }
}