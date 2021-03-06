﻿using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Exchanges
{
    public class ExchangesSupportingAssetResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<ExchangeSupportingAsset> Infos { get; protected set; } = new List<ExchangeSupportingAsset>();

        protected override IEnumerable<object> GetItems => Infos;
    }
}