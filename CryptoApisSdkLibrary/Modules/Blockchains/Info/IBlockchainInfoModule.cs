using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Info
{
    public interface IBlockchainInfoModule
    {
        /// <summary>
        /// General information about a BTC-similar blockchain.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        GetBtcInfoResponse GetInfo(BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// General information about a ETH-similar blockchain.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        GetEthInfoResponse GetInfo(EthSimilarCoin coin, EthSimilarNetwork network);

        /// <summary>
        /// Information for particular block in the BTC-similar blockchain.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="blockHash">Hash of the block in blockchain.</param>
        GetBtcHashInfoResponse GetBlockHash(BtcSimilarCoin coin, BtcSimilarNetwork network, string blockHash);

        /// <summary>
        /// Information for particular block in the ETH-similar blockchain.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="blockHash">Hash of the block in blockchain.</param>
        GetEthHashInfoResponse GetBlockHash(EthSimilarCoin coin, EthSimilarNetwork network, string blockHash);

        /// <summary>
        /// Information for particular block in the BTC-similar blockchain.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="blockHeight">Height of the block in blockchain.</param>
        GetBtcHashInfoResponse GetBlockHeigh(BtcSimilarCoin coin, BtcSimilarNetwork network, int blockHeight);

        /// <summary>
        /// Information for particular block in the ETH-similar blockchain.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="blockHeight">Height of the block in blockchain.</param>
        GetEthHashInfoResponse GetBlockHeigh(EthSimilarCoin coin, EthSimilarNetwork network, int blockHeight);

        /// <summary>
        /// Information for the latest block in the BTC-similar blockchain.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        GetBtcHashInfoResponse GetLatestBlock(BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// Information for the latest block in the ETH-similar blockchain.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        GetEthHashInfoResponse GetLatestBlock(EthSimilarCoin coin, EthSimilarNetwork network);
    }
}