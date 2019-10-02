using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetUnconfirmedTransactions
{
    public abstract class BaseBtcSimilarCoin : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Transaction.GetUnconfirmedTransactions<GetUnconfirmedTransactionsResponse>(NetworkCoin);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Blockchains.Transaction.GetUnconfirmedTransactions<GetUnconfirmedTransactionsResponse>(NetworkCoin, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Blockchains.Transaction.GetUnconfirmedTransactions<GetUnconfirmedTransactionsResponse>(NetworkCoin, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Blockchains.Transaction.GetUnconfirmedTransactions<GetUnconfirmedTransactionsResponse>(NetworkCoin, skip, limit);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected override bool IsPerhapsNotAnExactMatch { get; } = true;
    }
}