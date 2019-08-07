using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Info
{
    public interface IBlockchainInfoModule
    {
        /// <summary>
        /// General information about a BTC-similar blockchain.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <see cref=""/>
        GetBtcInfoResponse GetInfo(BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// General information about a BTC-similar blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <see cref=""/>
        Task<GetBtcInfoResponse> GetInfoAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// General information about a ETH-similar blockchain.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <see cref=""/>
        GetEthInfoResponse GetInfo(EthSimilarCoin coin, EthSimilarNetwork network);

        /// <summary>
        /// General information about a ETH-similar blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <see cref=""/>
        Task<GetEthInfoResponse> GetInfoAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network);

        /// <summary>
        /// Information for particular block in the BTC-similar blockchain.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="blockHash">Hash of the block in blockchain.</param>
        /// <see cref=""/>
        GetBtcHashInfoResponse GetBlockHash(BtcSimilarCoin coin, BtcSimilarNetwork network, string blockHash);

        /// <summary>
        /// Information for particular block in the BTC-similar blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="blockHash">Hash of the block in blockchain.</param>
        /// <see cref=""/>
        Task<GetBtcHashInfoResponse> GetBlockHashAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string blockHash);

        /// <summary>
        /// Information for particular block in the ETH-similar blockchain.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="blockHash">Hash of the block in blockchain.</param>
        /// <see cref=""/>
        GetEthHashInfoResponse GetBlockHash(EthSimilarCoin coin, EthSimilarNetwork network, string blockHash);

        /// <summary>
        /// Information for particular block in the ETH-similar blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="blockHash">Hash of the block in blockchain.</param>
        /// <see cref=""/>
        Task<GetEthHashInfoResponse> GetBlockHashAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string blockHash);

        /// <summary>
        /// Information for particular block in the BTC-similar blockchain.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="blockHeight">Height of the block in blockchain.</param>
        /// <see cref=""/>
        GetBtcHashInfoResponse GetBlockHeigh(BtcSimilarCoin coin, BtcSimilarNetwork network, int blockHeight);

        /// <summary>
        /// Information for particular block in the BTC-similar blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="blockHeight">Height of the block in blockchain.</param>
        /// <see cref=""/>
        Task<GetBtcHashInfoResponse> GetBlockHeighAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, int blockHeight);

        /// <summary>
        /// Information for particular block in the ETH-similar blockchain.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="blockHeight">Height of the block in blockchain.</param>
        /// <see cref=""/>
        GetEthHashInfoResponse GetBlockHeigh(EthSimilarCoin coin, EthSimilarNetwork network, int blockHeight);

        /// <summary>
        /// Information for particular block in the ETH-similar blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="blockHeight">Height of the block in blockchain.</param>
        /// <see cref=""/>
        Task<GetEthHashInfoResponse> GetBlockHeighAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, int blockHeight);

        /// <summary>
        /// Information for the latest block in the BTC-similar blockchain.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <see cref=""/>
        GetBtcHashInfoResponse GetLatestBlock(BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// Information for the latest block in the BTC-similar blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <see cref=""/>
        Task<GetBtcHashInfoResponse> GetLatestBlockAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// Information for the latest block in the ETH-similar blockchain.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <see cref=""/>
        GetEthHashInfoResponse GetLatestBlock(EthSimilarCoin coin, EthSimilarNetwork network);

        /// <summary>
        /// Information for the latest block in the ETH-similar blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <see cref=""/>
        Task<GetEthHashInfoResponse> GetLatestBlockAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network);
    }
}