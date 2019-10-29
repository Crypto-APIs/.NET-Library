using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void ImportAddressAsWalletDash()
    {
      var walletName = "testImportWallet";
      var password = "SECRET123456";
      var privateKey = "8aeb39b5f9b0xxxxxxxc7001c1cecc112712c9448b";
      var address = "yVrjEE1zwXckCMXZoTStJtb9SJ29xr1ZMc";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
        NetworkCoin.DashMainNet, walletName, password, privateKey, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "ImportAddressAsWalletDash executed successfully, " +
          $"\"{response.Payload.Addresses.Count}\" addresses were imported "
        : $"ImportAddressAsWalletDash error: {response.ErrorMessage}");
    }
  }
}