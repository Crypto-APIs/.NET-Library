using CryptoApisLibrary.Modules.Blockchains;
using CryptoApisLibrary.Modules.Exchanges;

namespace CryptoApisLibrary
{
    public interface ICryptoManager
    {
        ITradeModules Exchanges { get; }
        IBlockchainModules Blockchains { get; }
        ITradeModules Trade { get; }
    }
}