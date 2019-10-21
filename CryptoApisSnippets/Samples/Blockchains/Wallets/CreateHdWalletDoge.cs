using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public string CreateHdWalletDoge()
    {
      var walletName = "DemoDogeWallet";
      var addressCount = 3;
      var password = "8a0690d2cd4fad1371090225217bb1425b3700210f51be6111eb225d5142ac32";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.CreateHdWallet<BtcHdWalletInfoResponse>(
        NetworkCoin.DogeMainNet, walletName, addressCount, password);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateHdWalletDoge executed successfully, " +
          $"HD wallet \"{response.Wallet.Name}\" created"
        : $"CreateHdWalletDoge error: {response.ErrorMessage}");

      return response.Wallet.Name;
    }
  }
}