using CryptoApisSdkLibrary.DataTypes.Exceptions;
using RestSharp.Deserializers;
using System;

namespace CryptoApisSdkLibrary.DataTypes
{
    public class ExchangeSupportingPairs //: IEquatable<ExchangeSupportingPairs>
    {
        /// <summary>
        /// Unique symbol identification string (UID).
        /// </summary>
        [DeserializeAs(Name = "symbolId")]
        public string SymbolId { get; protected set; }

        /// <summary>
        /// Our identifier (UID) of the exchange where symbol is traded.
        /// </summary>
        [DeserializeAs(Name = "exchangeId")]
        public string ExchangeId { get; protected set; }

        /// <summary>
        /// Our symbol identifier, see table below for format description.
        /// </summary>
        [DeserializeAs(Name = "exchangeSymbol")]
        public string ExchangeSymbol { get; protected set; }

        /// <summary>
        /// FX Spot base asset identifier (UID), for derivatives it’s contact underlying (e.g. BTC for BTC/USD)
        /// </summary>
        [DeserializeAs(Name = "baseAsset")]
        public string BaseAsset { get; protected set; }

        /// <summary>
        /// FX Spot quote asset identifier (UID), for derivatives it’s contract underlying (e.g. USD for BTC/USD)
        /// </summary>
        [DeserializeAs(Name = "quoteAsset")]
        public string quoteAsset { get; protected set; }

        /// <summary>
        /// Type of symbol (possible values are: SPOT, FUTURES or OPTION)
        /// </summary>
        [DeserializeAs(Name = "tradeType")]
        public string TradeTypeAsString { get; protected set; }

        /// <summary>
        /// Exchange type, where the initial quote took place.
        /// </summary>
        public TradeType TradeType
        {
            get
            {
                if ("SPOT".Equals(TradeTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return TradeType.Spot;
                if ("FUTURES".Equals(TradeTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return TradeType.Futures;
                if ("OPTION".Equals(TradeTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return TradeType.Option;

                throw new UndefineTradeTypeException(TradeTypeAsString);
            }
        }

        public override string ToString()
        {
            return ExchangeSymbol;
        }

        #region IEquatable<ExchangeSupportingPairs>
        // !!!!!!!!!!!!!!!!!!!!
        #endregion
    }
}