using CryptoApisSdkLibrary.DataTypes;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void SignTransactionLtc()
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;
      var hexEncodedInfo =
        "0200000001c23eb3952f521c15a429ece05b815464dff5f47b5e9d56c53049a314dad0224f0000000000ffffffff022060cd07000000001976a9141eea2f620c6ab7d6f1b9c18aa42b1f0cef46eddb88ac7be8130a000000001976a914ccb83dc9e4acdf15fc16d5c5af6a09d988baef3088ac00000000";
      var wifs = new List<string> { "cQQf41Y7Ek5YAXzUPcQE8HsBCaQV7QAx14sJf54KQ91BRhM24ToC" };
            
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.SignTransaction(
        coin, network, hexEncodedInfo, wifs);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"SignTransactionLtc executed successfully, return hex is {response.Payload.Hex}"
        : $"SignTransactionLtc error: {response.ErrorMessage}");
    }
  }
}