using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetXPubReceiveAddressesBch()
    {
      var xpub = "xpub68sZmWTsr2FYYr8RGHG9Yu1JtZkAUSAQnJmB1UxFFMeaGqFTgbe3MZLpiLKodsiyrRrsq9k4DLCPxFvuw94AKTihXQHWQGpbvG7ACaNWK6h";
      var startIndex = 0;
      var finishIndex = 3;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetXPubReceiveAddresses<GetXPubAddressesResponse>(
        NetworkCoin.BchMainNet, xpub, startIndex, finishIndex);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetXPubReceiveAddressesBch executed successfully, " +
          $"\"{response.Addresses.Count}\" addresses were created "
        : $"GetXPubReceiveAddressesBch error: {response.ErrorMessage}");
    }
  }
}