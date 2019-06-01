using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetUnconfirmedTransactions
{
    public abstract class BaseBtcSimilarCoin : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Transaction.GetUnconfirmedTransactions(Coin, Network);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Blockchains.Transaction.GetUnconfirmedTransactions(Coin, Network, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Blockchains.Transaction.GetUnconfirmedTransactions(Coin, Network, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Blockchains.Transaction.GetUnconfirmedTransactions(Coin, Network, skip, limit);
        }

        protected abstract BtcSimilarCoin Coin { get; }
        protected abstract BtcSimilarNetwork Network { get; }
        protected override bool IsPerhapsNotAnExactMatch { get; } = true;
    }
}