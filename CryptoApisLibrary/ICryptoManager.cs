using CryptoApisLibrary.Modules.Blockchains;
using CryptoApisLibrary.Modules.Exchanges;

namespace CryptoApisLibrary
{
    public interface ICryptoManager
    {
        IExchangeModules Exchanges { get; }
        IBlockchainModules Blockchains { get; }
    }
}