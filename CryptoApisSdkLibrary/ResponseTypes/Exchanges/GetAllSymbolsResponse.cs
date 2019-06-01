using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class GetAllSymbolsResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<Symbol> Symbols { get; protected set; } = new List<Symbol>();

        protected override IEnumerable<object> GetItems => Symbols;
    }
}