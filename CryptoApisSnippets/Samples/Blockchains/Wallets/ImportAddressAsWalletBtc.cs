using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void ImportAddressAsWalletBtc()
    {
      var walletName = "testImportWallet";
      var password = "SECRET123456";
      var privateKey = "8aeb39b5f9b0xxxxxxxc7001c1cecc112712c9448b";
      var address = "mn6GtNFRPwXtW7xJqH8Afck7FbVoRi6NF1";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
        NetworkCoin.BtcMainNet, walletName, password, privateKey, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "ImportAddressAsWalletBtc executed successfully, " +
          $"\"{response.Payload.Addresses.Count}\" addresses were imported "
        : $"ImportAddressAsWalletBtc error: {response.ErrorMessage}");
    }
  }
}