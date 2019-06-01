using CryptoApisSdkLibrary.DataTypes.Exceptions;
using RestSharp.Deserializers;
using System;

namespace CryptoApisSdkLibrary.DataTypes
{
    public class ArbitrageInfo : IEquatable<ArbitrageInfo>
    {
        /// <summary>
        /// Exchange name, where the initial quote took place.
        /// </summary>
        [DeserializeAs(Name = "initExchange")]
        public string InitExchange { get; protected set; }

        /// <summary>
        /// Base asset name, where the initial quote took place.
        /// </summary>
        [DeserializeAs(Name = "initBaseAsset")]
        public string InitBaseAsset { get; protected set; }

        /// <summary>
        /// Quote asset name, where the initial quote took place.
        /// </summary>
        [DeserializeAs(Name = "initQuoteAsset")]
        public string InitQuoteAsset { get; protected set; }

        /// <summary>
        /// Exchange type, where the initial quote took place.
        /// </summary>
        [DeserializeAs(Name = "initExchangeType")]
        public string InitExchangeTypeAsString { get; protected set; }

        /// <summary>
        /// Direction, where the initial quote took place.
        /// </summary>
        [DeserializeAs(Name = "initDirection")]
        public string InitDirectionAsString { get; protected set; }

        /// <summary>
        /// Base asset whole unit price in quote assets, where the initial quote took place.
        /// </summary>
        [DeserializeAs(Name = "initPrice")]
        public double InitPrice { get; protected set; }

        /// <summary>
        /// Amount of base asset, where the initial quote took place.
        /// </summary>
        [DeserializeAs(Name = "initAmount")]
        public double InitAmount { get; protected set; }

        /// <summary>
        /// Exchange fee in USD needed for the trade, where the initial quote took place.
        /// </summary>
        [DeserializeAs(Name = "initFee")]
        public double InitFee { get; protected set; }

        /// <summary>
        /// Exchange name, where the matching quote took place.
        /// </summary>
        [DeserializeAs(Name = "matchExchange")]
        public string MatchExchange { get; protected set; }

        /// <summary>
        /// Base asset name, where the matching quote took place.
        /// </summary>
        [DeserializeAs(Name = "matchBaseAsset")]
        public string MatchBaseAsset { get; protected set; }

        /// <summary>
        /// Quote asset name, where the matching quote took place.
        /// </summary>
        [DeserializeAs(Name = "matchQuoteAsset")]
        public string MatchQuoteAsset { get; protected set; }

        /// <summary>
        /// Exchange type, where the matching quote took place.
        /// </summary>
        [DeserializeAs(Name = "matchExchangeType")]
        public string MatchExchangeTypeAsString { get; protected set; }

        /// <summary>
        /// Direction, where the matching quote took place.
        /// </summary>
        [DeserializeAs(Name = "matchDirection")]
        public string MatchDirectionAsString { get; protected set; }

        /// <summary>
        /// Base asset whole unit price in quote assets, where the matching quote took place.
        /// </summary>
        [DeserializeAs(Name = "matchPrice")]
        public double MatchPrice { get; protected set; }

        /// <summary>
        /// Amount of base asset, where the matching quote took place.
        /// </summary>
        [DeserializeAs(Name = "matchAmount")]
        public double MatchAmount { get; protected set; }

        /// <summary>
        /// Exchange fee in USD needed for the trade, where the matching quote took place.
        /// </summary>
        [DeserializeAs(Name = "matchFee")]
        public double MatchFee { get; protected set; }

        /// <summary>
        /// Difference between initial and matching price in USD.
        /// </summary>
        [DeserializeAs(Name = "priceDifference")]
        public double PriceDifference { get; protected set; }

        /// <summary>
        /// Quote asset whole unit price in USD when the matching happened, where the initial quote took place.
        /// </summary>
        [DeserializeAs(Name = "quoteAssetUSDPrice")]
        public double QuoteAssetUsdPrice { get; protected set; }

        /// <summary>
        /// Quote asset whole unit price in USD when the matching happened, where the initial quote took place.
        /// </summary>
        [DeserializeAs(Name = "investmentUSD")]
        public double InvestmentUsd { get; protected set; }

        /// <summary>
        /// Profit in USD without the exchanges fees if the trade was made.
        /// </summary>
        [DeserializeAs(Name = "profitWithoutFees")]
        public double ProfitWithoutFees { get; protected set; }

        /// <summary>
        /// Base asset whole unit price in USD when the matching happened, where the initial quote took place.
        /// </summary>
        [DeserializeAs(Name = "baseAssetUSDPrice")]
        public double BaseAssetUsdPrice { get; protected set; }

        /// <summary>
        /// Quote asset whole unit price in USD when the matching happened, where the matching quote took place.
        /// </summary>
        [DeserializeAs(Name = "matchQuoteAssetUSDPrice")]
        public double MatchQuoteAssetUsdPrice { get; protected set; }

        /// <summary>
        /// Base asset whole unit price in USD when the matching happened, where the matching quote took place.
        /// </summary>
        [DeserializeAs(Name = "matchBaseAssetUSDPrice")]
        public double MatchBaseAssetUsdPrice { get; protected set; }

        /// <summary>
        /// Unique string identifier of the initial quote.
        /// </summary>
        [DeserializeAs(Name = "matched")]
        public string Matched { get; protected set; }

        /// <summary>
        /// If grouped is true the initial quote has been matched with other matching quotes in order to trade the maximum amount.
        /// </summary>
        [DeserializeAs(Name = "grouped")]
        public bool Grouped { get; protected set; }

        /// <summary>
        /// Can be one of: , negative_correlation_quote_quote.
        /// </summary>
        [DeserializeAs(Name = "matchType")]
        public string MatchTypeAsString { get; protected set; }

        /// <summary>
        /// Identifier.
        /// </summary>
        [DeserializeAs(Name = "_id")]
        public string Id { get; protected set; }

        /// <summary>
        /// Type of match.
        /// </summary>
        public MatchType MatchType
        {
            get
            {
                if ("positive".Equals(MatchTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return MatchType.Positive;
                if ("negative".Equals(MatchTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return MatchType.Negative;
                if ("positive_correlation_base_quote".Equals(MatchTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return MatchType.PositiveCorrelationBaseQuote;
                if ("positive_correlation_quote_base".Equals(MatchTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return MatchType.PositiveCorrelationQuoteBase;
                if ("negative_correlation_base_base".Equals(MatchTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return MatchType.NegativeCorrelationBaseBase;
                if ("negative_correlation_quote_quote".Equals(MatchTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return MatchType.NegativeCorrelationQuoteQuote;

                throw new UndefineMatchTypeException(MatchTypeAsString);
            }
        }

        /// <summary>
        /// Exchange type, where the initial quote took place.
        /// </summary>
        public TradeType InitExchangeType
        {
            get
            {
                if ("SPOT".Equals(InitExchangeTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return TradeType.Spot;
                if ("FUTURES".Equals(InitExchangeTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return TradeType.Futures;
                if ("OPTION".Equals(InitExchangeTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return TradeType.Option;

                throw new UndefineTradeTypeException(InitExchangeTypeAsString);
            }
        }

        /// <summary>
        /// Exchange type, where the matching quote took place.
        /// </summary>
        public TradeType MatchExchangeType
        {
            get
            {
                if ("SPOT".Equals(MatchExchangeTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return TradeType.Spot;
                if ("FUTURES".Equals(MatchExchangeTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return TradeType.Futures;
                if ("OPTION".Equals(MatchExchangeTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return TradeType.Option;

                throw new UndefineTradeTypeException(MatchExchangeTypeAsString);
            }
        }

        /// <summary>
        /// Direction, where the initial quote took place.
        /// </summary>
        public QuoteTradeDirection InitDirection
        {
            get
            {
                if ("ASKS".Equals(InitDirectionAsString, StringComparison.OrdinalIgnoreCase))
                    return QuoteTradeDirection.Asks;
                if ("BIDS".Equals(InitDirectionAsString, StringComparison.OrdinalIgnoreCase))
                    return QuoteTradeDirection.Bids;

                throw new UndefineQuoteTradeDirectionException(InitDirectionAsString);
            }
        }

        /// <summary>
        /// Direction, where the initial quote took place.
        /// </summary>
        public QuoteTradeDirection MatchDirection
        {
            get
            {
                if ("ASKS".Equals(MatchDirectionAsString, StringComparison.OrdinalIgnoreCase))
                    return QuoteTradeDirection.Asks;
                if ("BIDS".Equals(MatchDirectionAsString, StringComparison.OrdinalIgnoreCase))
                    return QuoteTradeDirection.Bids;

                throw new UndefineQuoteTradeDirectionException(MatchDirectionAsString);
            }
        }

        #region IEquatable<QuoteTrade>

        public bool Equals(ArbitrageInfo other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(InitExchange, other.InitExchange) && string.Equals(InitBaseAsset, other.InitBaseAsset)
                && string.Equals(InitQuoteAsset, other.InitQuoteAsset)
                && string.Equals(InitExchangeTypeAsString, other.InitExchangeTypeAsString)
                && string.Equals(InitDirectionAsString, other.InitDirectionAsString) && InitPrice.Equals(other.InitPrice)
                && InitAmount.Equals(other.InitAmount) && InitFee.Equals(other.InitFee)
                && string.Equals(MatchExchange, other.MatchExchange) && string.Equals(MatchBaseAsset, other.MatchBaseAsset)
                && string.Equals(MatchQuoteAsset, other.MatchQuoteAsset)
                && string.Equals(MatchExchangeTypeAsString, other.MatchExchangeTypeAsString)
                && string.Equals(MatchDirectionAsString, other.MatchDirectionAsString) && MatchPrice.Equals(other.MatchPrice)
                && MatchAmount.Equals(other.MatchAmount) && MatchFee.Equals(other.MatchFee)
                && PriceDifference.Equals(other.PriceDifference) && QuoteAssetUsdPrice.Equals(other.QuoteAssetUsdPrice)
                && InvestmentUsd.Equals(other.InvestmentUsd) && ProfitWithoutFees.Equals(other.ProfitWithoutFees)
                && BaseAssetUsdPrice.Equals(other.BaseAssetUsdPrice) && MatchQuoteAssetUsdPrice.Equals(other.MatchQuoteAssetUsdPrice)
                && MatchBaseAssetUsdPrice.Equals(other.MatchBaseAssetUsdPrice) && string.Equals(Matched, other.Matched)
                && Grouped == other.Grouped && string.Equals(MatchTypeAsString, other.MatchTypeAsString) && string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == this.GetType() && Equals((ArbitrageInfo)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (InitExchange != null ? InitExchange.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (InitBaseAsset != null ? InitBaseAsset.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (InitQuoteAsset != null ? InitQuoteAsset.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (InitExchangeTypeAsString != null ? InitExchangeTypeAsString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (InitDirectionAsString != null ? InitDirectionAsString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ InitPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ InitAmount.GetHashCode();
                hashCode = (hashCode * 397) ^ InitFee.GetHashCode();
                hashCode = (hashCode * 397) ^ (MatchExchange != null ? MatchExchange.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MatchBaseAsset != null ? MatchBaseAsset.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MatchQuoteAsset != null ? MatchQuoteAsset.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MatchExchangeTypeAsString != null ? MatchExchangeTypeAsString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MatchDirectionAsString != null ? MatchDirectionAsString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ MatchPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ MatchAmount.GetHashCode();
                hashCode = (hashCode * 397) ^ MatchFee.GetHashCode();
                hashCode = (hashCode * 397) ^ PriceDifference.GetHashCode();
                hashCode = (hashCode * 397) ^ QuoteAssetUsdPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ InvestmentUsd.GetHashCode();
                hashCode = (hashCode * 397) ^ ProfitWithoutFees.GetHashCode();
                hashCode = (hashCode * 397) ^ BaseAssetUsdPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ MatchQuoteAssetUsdPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ MatchBaseAssetUsdPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ (Matched != null ? Matched.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Grouped.GetHashCode();
                hashCode = (hashCode * 397) ^ (MatchTypeAsString != null ? MatchTypeAsString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Id != null ? Id.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<QuoteTrade>
    }
}