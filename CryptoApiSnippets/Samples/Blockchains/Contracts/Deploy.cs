using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void Deploy()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Rinkeby;
      var fromAddress = "0xe7cc96ba0562dfba61a55c8dd2e162a30942f402";
      double gasPrice = 21000000000;
      double gasLimit = 2100000;
      var privateKey = "4f75aff19dd7acbf7c4d5d6f736176a3fe2db1ec9b60cc11d30dc3c343520ed1";
      var byteCode = "0x60806040523480156200001157600080fd5b50336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506040805190810160405280600481526020017f4d464b54000000000000000000000000000000000000000000000000000000008fffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156116b457600080fd5b80600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373fffff...ffffffffffffffffffffffffffffffffff16021790555050565b600082821115151561170957600080fd5b8183039050929150505600a165627a7a72305820d5c331e320cecd2d4312d2652403d5e25028a60929540b4a8ededb52575622a40029";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Contract.Deploy(
        coin, network, fromAddress, gasPrice, gasLimit, privateKey, byteCode);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"Deploy executed successfully, TransactionHash is {response.Payload.Hex}"
        : $"Deploy error: {response.ErrorMessage}");
    }
  }
}