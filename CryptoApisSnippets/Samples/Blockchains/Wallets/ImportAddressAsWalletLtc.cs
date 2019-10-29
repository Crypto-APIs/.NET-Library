using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void ImportAddressAsWalletLtc()
    {
      var walletName = "testImportWallet";
      var password = "SECRET123456";
      var privateKey = "8aeb39b5f9b0xxxxxxxc7001c1cecc112712c9448b";
      var address = "mzBQrW3t9XKx9x1Wh7mkxagVo3Kc6U7Z2H";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
        NetworkCoin.LtcMainNet, walletName, password, privateKey, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "ImportAddressAsWalletLtc executed successfully, " +
          $"\"{response.Payload.Addresses.Count}\" addresses were imported "
        : $"ImportAddressAsWalletLtc error: {response.ErrorMessage}");
    }
  }
}