using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void ImportAddressAsWalletDoge()
    {
      var walletName = "testImportWallet";
      var password = "SECRET123456";
      var privateKey = "8aeb39b5f9b0xxxxxxxc7001c1cecc112712c9448b";
      var address = "no3yJMxBSKzq6wuUNLN7cUssfPGTiRbb5c";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
        NetworkCoin.DogeMainNet, walletName, password, privateKey, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "ImportAddressAsWalletDoge executed successfully, " +
          $"\"{response.Payload.Addresses.Count}\" addresses were imported "
        : $"ImportAddressAsWalletDoge error: {response.ErrorMessage}");
    }
  }
}