using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Exchanges
{
    public class SymbolsResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<Symbol> Symbols { get; protected set; } = new List<Symbol>();

        protected override IEnumerable<object> GetItems => Symbols;
    }
}