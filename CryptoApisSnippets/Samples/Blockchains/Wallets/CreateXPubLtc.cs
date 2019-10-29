using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateXPubLtc()
    {
      var password = "SECRET123456";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.CreateXPub<CreateXPubResponse>(
        NetworkCoin.LtcMainNet, password);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateXPubLtc executed successfully, " +
          $"created Xpub is \"{response.Payload.Xpub}\""
        : $"CreateXPubLtc error: {response.ErrorMessage}");
    }
  }
}