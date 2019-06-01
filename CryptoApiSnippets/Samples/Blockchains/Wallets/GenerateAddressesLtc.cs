using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GenerateAddressesLtc(string walletName)
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GenerateAddress(
        coin, network, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GenerateAddressesLtc executed successfully, " +
          $"{response.Payload.Wallet.Addresses.Count} addresses of \"{response.Payload.Wallet.Name}\" wallet returned"
        : $"GenerateAddressesLtc error: {response.ErrorMessage}");
    }
  }
}