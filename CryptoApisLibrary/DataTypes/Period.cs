using RestSharp.Deserializers;

namespace CryptoApisLibrary.DataTypes
{
    public class Period
    {
        /// <summary>
        /// Period Identifier used by Crypto APIs.
        /// </summary>
        [DeserializeAs(Name = "period")]
        public string Id { get; protected set; }

        /// <summary>
        /// Exchange rate between assets calculated by median of the last trades in every exchange for the last 24 hours.
        /// </summary>
        [DeserializeAs(Name = "lengthInSeconds")]
        public int LengthInSeconds { get; protected set; }

        /// <summary>
        /// Months part of period length.
        /// </summary>
        [DeserializeAs(Name = "lengthInMonths")]
        public int? LengthInMonths { get; protected set; }

        /// <summary>
        /// Period length in units.
        /// </summary>
        [DeserializeAs(Name = "unitCount")]
        public int UnitCount { get; protected set; }

        /// <summary>
        /// Type of time-series used (second/minute/hour/day/year).
        /// </summary>
        [DeserializeAs(Name = "unitName")]
        public string UnitName { get; protected set; }

        /// <summary>
        /// Display name of period length.
        /// </summary>
        [DeserializeAs(Name = "displayName")]
        public string DisplayName { get; protected set; }

        public Period()
        {
        }

        public Period(string period)
        {
            Id = period;
        }

        public override string ToString()
        {
            return Id;
        }
    }
}