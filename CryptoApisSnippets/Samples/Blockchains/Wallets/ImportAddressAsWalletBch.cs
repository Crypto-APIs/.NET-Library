using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void ImportAddressAsWalletBch()
    {
      var walletName = "testImportWallet";
      var password = "SECRET123456";
      var privateKey = "8aeb39b5f9b0xxxxxxxc7001c1cecc112712c9448b";
      var address = "mv79B1CSYTzVJPH1jky6wESrMSMZ7Nj2nz";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
        NetworkCoin.BchMainNet, walletName, password, privateKey, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "ImportAddressAsWalletBch executed successfully, " +
          $"\"{response.Payload.Addresses.Count}\" addresses were imported "
        : $"ImportAddressAsWalletBch error: {response.ErrorMessage}");
    }
  }
}