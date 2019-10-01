using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void RemoveAddressesLtc(string walletName, string address)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.RemoveAddress<RemoveAddressResponse>(
        NetworkCoin.LtcMainNet, walletName, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "RemoveAddressesLtc executed successfully" 
        : $"RemoveAddressesLtc error: {response.ErrorMessage}");
    }
  }
}