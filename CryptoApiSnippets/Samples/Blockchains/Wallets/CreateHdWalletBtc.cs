using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public string CreateHdWalletBtc()
    {
      var walletName = "DemoBtcWallet";
      var addressCount = 3;
      var password = "8a0690d2cd4fad1371090225217bb1425b3700210f51be6111eb225d5142ac32";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.CreateHdWallet<HdWalletInfoResponse>(
        NetworkCoin.BtcMainNet, walletName, addressCount, password);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateHdWalletBtc executed successfully, " +
          $"HD wallet \"{response.Wallet.Name}\" created"
        : $"CreateHdWalletBtc error: {response.ErrorMessage}");

      return response.Wallet.Name;
    }
  }
}