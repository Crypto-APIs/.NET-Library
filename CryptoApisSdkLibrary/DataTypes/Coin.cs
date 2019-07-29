using System;

namespace CryptoApisSdkLibrary.DataTypes
{
    public abstract class Coin : IEquatable<Coin>
    {
        protected Coin(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        private string Value { get; }

        public static bool operator ==(Coin a, Coin b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Coin a, Coin b)
        {
            return !(a == b);
        }

        #region IEquatable<Coin>

        public bool Equals(Coin other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == this.GetType() && Equals((Coin)obj);
        }

        public override int GetHashCode()
        {
            return Value != null ? Value.GetHashCode() : 0;
        }

        #endregion IEquatable<Coin>
    }

    public class BtcSimilarCoin : Coin
    {
        public static BtcSimilarCoin Btc => new BtcSimilarCoin("btc");
        public static BtcSimilarCoin Bch => new BtcSimilarCoin("bch");
        public static BtcSimilarCoin Ltc => new BtcSimilarCoin("ltc");
        public static BtcSimilarCoin Doge => new BtcSimilarCoin("doge");
        public static BtcSimilarCoin Dash => new BtcSimilarCoin("dash");

        private BtcSimilarCoin(string value) : base(value)
        {
        }
    }

    public class EthSimilarCoin : Coin
    {
        public static EthSimilarCoin Eth => new EthSimilarCoin("eth");

        private EthSimilarCoin(string value) : base(value)
        {
        }
    }
}