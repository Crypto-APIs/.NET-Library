using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public string CreateHierarchicalDeterministicWalletDash()
    {
      var coin = BtcSimilarCoin.Dash;
      var network = BtcSimilarNetwork.Mainnet;
      var walletName = "DemoDashWallet";
      var addressCount = 3;
      var password = "8a0690d2cd4fad1371090225217bb1425b3700210f51be6111eb225d5142ac32";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.CreateHdWallet(
        coin, network, walletName, addressCount, password);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateHierarchicalDeterministicWalletDash executed successfully, " +
          $"HD wallet \"{response.Wallet.Name}\" created"
        : $"CreateHierarchicalDeterministicWalletDash error: {response.ErrorMessage}");

      return response.Wallet.Name;
    }
  }
}