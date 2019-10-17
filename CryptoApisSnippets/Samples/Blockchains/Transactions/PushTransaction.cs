using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void PushTransaction()
    {
      var hexEncodedInfo = "0xf86a22827d00831e8480941b85a43e2e7f52e766ddfdfa2b901c42cb1201be8801b27f33b807c0008029a084ccbf02b27e0842fb1eda7a187a5589c3759be0e969e0ca989dc469a5e5e394a02e111e1156b197f1de4c1d9ba4af26e50665ea6d617d05b3e4047da12b915e69";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.PushTransaction<PushTransactionResponse>(
        NetworkCoin.EthMainNet, hexEncodedInfo);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "PushTransaction executed successfully, " +
          $"TransactionHash \"{response.Payload.Hex}\""
        : $"PushTransaction error: {response.ErrorMessage}");
    }
  }
}