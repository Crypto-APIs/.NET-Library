using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class GetAllPeriodsResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<Period> Periods { get; protected set; } = new List<Period>();

        protected override IEnumerable<object> GetItems => Periods;
    }
}