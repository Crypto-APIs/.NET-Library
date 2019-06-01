using CryptoApisSdkLibrary.DataTypes;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void SignTransactionBtc()
    {
      var coin = BtcSimilarCoin.Btc;
      var network = BtcSimilarNetwork.Mainnet;
      var hexEncodedInfo =
        "020000000393d3ba1a02fd978b494e79ed199247079eb4f766fadc0b807c0734d4b18bd9810000000000ffffffff7dbd03383a240f27c7735af707e823da894e11732c5fe5919adff1672b817be00100000000ffffffff7dbd03383a240f27c7735af707e823da894e11732c5fe5919adff1672b817be00200000000ffffffff0320bf0200000000001976a9147b9a627a184897f10d31d73d87c2eea191d8f50188ac08c60000000000001976a9148bafc8dad0c87025278b4cc1c80ac8d402cb59eb88ac0c8c0000000000001976a914481e003d23566c1789dc9362085c3a0876570c7c88ac00000000";
      var wifs = new List<string> { "cSEjySAREyai8eQhgoqixzmxCeSP8QtbwHxptL8ijofg68ZMjoud" };
            
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.SignTransaction(
        coin, network, hexEncodedInfo, wifs);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"SignTransactionBtc executed successfully, return hex is {response.Payload.Hex}"
        : $"SignTransactionBtc error: {response.ErrorMessage}");
    }
  }
}