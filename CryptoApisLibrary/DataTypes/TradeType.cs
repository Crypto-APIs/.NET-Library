namespace CryptoApisLibrary.DataTypes
{
    public enum TradeType
    {
        /// <summary>
        /// Agreement to exchange one asset for another one (e.g. Buy Btc for USD).
        /// </summary>
        Spot,

        /// <summary>
        /// FX Spot derivative contract where traders agree to trade fx spot at predetermined future time.
        /// </summary>
        Futures,

        /// <summary>
        /// FX Spot derivative contract where traders agree to trade right to require buy or sell of fx spot at agreed price on exercise date.
        /// </summary>
        Option
    }
}