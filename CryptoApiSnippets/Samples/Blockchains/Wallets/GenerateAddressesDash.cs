using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GenerateAddressesDash(string walletName)
    {
      var coin = BtcSimilarCoin.Dash;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GenerateAddress(
        coin, network, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GenerateAddressesDash executed successfully, " +
          $"{response.Payload.Wallet.Addresses.Count} addresses of \"" +
          $"{response.Payload.Wallet.Name}\" wallet returned"
        : $"GenerateAddressesDash error: {response.ErrorMessage}");
    }
  }
}