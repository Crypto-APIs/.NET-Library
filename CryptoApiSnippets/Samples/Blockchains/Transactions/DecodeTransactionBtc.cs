using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DecodeTransactionBtc()
    {
      var hexEncodedInfo = "0200000005c1ab663c05cc557f522d55d42734eb3fe7bfacf3737cba5102233b312b0c95590000000000ffffffffbfd5dc9ac3129f2a9788d0ab2c201861790d66ce147bf6ebe8ee44019b69ed790100000000ffffffff2837839555246cc3f0f9374f73030341d641f3beae71eeafb2461f8ba8daa1d40000000000ffffffffbe23166dca2f0b9a24d9704e5e6ecfe3e57265cda29468e68c19644d24e1f1c70000000000ffffffff41994176b4bb3f00bb128a982b907e0a3b139ac02d90253c61815dea3d16f98d0000000000ffffffff0140420f00000000001976a9141a96349a5025735fe18f3e783098e471edbad83388ac00000000";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.DecodeTransaction<BtcDecodeTransactionResponse>(
        NetworkCoin.BtcMainNet, hexEncodedInfo);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DecodeTransactionBtc executed successfully, " +
          $"Transaction hash is \"{response.Transaction.Hash}\""
        : $"DecodeTransactionBtc error: {response.ErrorMessage}");
    }
  }
}