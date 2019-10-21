using RestSharp.Deserializers;
using System;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class GetTokenTotalSupplyAndDecimalsResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public ResponsePayload Payload { get; protected set; }

        public class ResponsePayload : IEquatable<ResponsePayload>
        {
            [DeserializeAs(Name = "decimals")]
            public int Decimals { get; protected set; }

            [DeserializeAs(Name = "totalSupply")]
            public long TotalSupply { get; protected set; }

            #region IEquatable<ResponsePayload>

            public bool Equals(ResponsePayload other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Decimals == other.Decimals && TotalSupply == other.TotalSupply;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((ResponsePayload)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (Decimals * 397) ^ TotalSupply.GetHashCode();
                }
            }

            #endregion IEquatable<ResponsePayload>
        }
    }
}