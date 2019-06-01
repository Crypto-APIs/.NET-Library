using CryptoApisSdkLibrary.Modules;
using CryptoApisSdkLibrary.Modules.Blockchains;
using CryptoApisSdkLibrary.Modules.Exchanges;

namespace CryptoApisSdkLibrary
{
    public interface ICryptoManager
    {
        IExchangeModules Exchanges { get; }
        IBlockchainModules Blockchains { get; }
    }
}