using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void SignTransactionBch()
    {
      var hexEncodedInfo =
        "020000000133c23cd5a0a74e5775fc60cbd0838f032968e1e88f64acb951ffd8f7b9a4cea70000000000ffffffff0208b70400000000001976a914392f49c5a9b85d4f3de6996ef88af204d3ab425688acd3300a00000000001976a914c06fa3357499eb2d7b7f0b01824b5847727e02d288ac00000000";
      var wifs = new List<string> { "cSKbuySxbKm4uQK9SQQRjpsZfENNBrFxKm3rmoMER9ua6XR79Shs" };
            
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.SignTransaction<SignBtcTransactionResponse>(
        NetworkCoin.BchTestNet, hexEncodedInfo, wifs);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "SignTransactionBch executed successfully, " +
          $"return hex is {response.Payload.Hex}"
        : $"SignTransactionBch error: {response.ErrorMessage}");
    }
  }
}