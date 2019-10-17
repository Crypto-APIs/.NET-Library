using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Exchanges
{
    public class PeriodsResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<Period> Periods { get; protected set; } = new List<Period>();

        protected override IEnumerable<object> GetItems => Periods;
    }
}