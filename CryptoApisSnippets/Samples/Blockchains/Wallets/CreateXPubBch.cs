using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateXPubBch()
    {
      var password = "SECRET123456";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.CreateXPub<CreateXPubResponse>(
        NetworkCoin.BchMainNet, password);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateXPubBch executed successfully, " +
          $"created Xpub is \"{response.Payload.Xpub}\""
        : $"CreateXPubBch error: {response.ErrorMessage}");
    }
  }
}