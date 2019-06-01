namespace CryptoApisSdkLibrary.DataTypes
{
    /// <summary>
    /// Aggressor side of the transaction.
    /// </summary>
    public enum TradeDirection
    {
        /// <summary>
        /// Exchange has reported that transaction aggressor was buying.
        /// </summary>
        Buy,

        /// <summary>
        /// Exchange has reported that transaction aggressor was selling.
        /// </summary>
        Sell,

        /// <summary>
        /// Exchange has not reported transaction aggressor, we estimated that more likely it was buying.
        /// </summary>
        BuyEstimated,

        /// <summary>
        /// Exchange has not reported transaction aggressor, we estimated that more likely it was selling.
        /// </summary>
        SellEstimated,

        /// <summary>
        /// Exchange has not reported transaction aggressor and we have not estimated who it was.
        /// </summary>
        Unknown
    }
}