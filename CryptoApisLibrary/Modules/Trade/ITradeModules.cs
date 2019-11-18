using CryptoApisLibrary.Modules.Trade.Accounts;
using CryptoApisLibrary.Modules.Trade.Arbitrage;
using CryptoApisLibrary.Modules.Trade.Private;

namespace CryptoApisLibrary.Modules.Trade
{
    public interface ITradeModules
    {
        ITradeAccountsModules Accounts { get; }
        ITradePrivateModules Private { get; }
        ITradeArbitrageModules Arbitrage { get; }
    }
}