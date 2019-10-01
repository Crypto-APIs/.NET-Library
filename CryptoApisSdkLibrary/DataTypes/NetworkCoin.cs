using System;

namespace CryptoApisSdkLibrary.DataTypes
{
    public class NetworkCoin : IEquatable<NetworkCoin>
    {
        protected NetworkCoin(Coin coin, Network network)
        {
            Coin = coin;
            Network = network;
        }

        public override string ToString()
        {
            return $"{Coin}/{Network}";
        }

        public Coin Coin { get; }
        public Network Network { get; }

        public static bool operator ==(NetworkCoin a, NetworkCoin b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(NetworkCoin a, NetworkCoin b)
        {
            return !(a == b);
        }

        public static NetworkCoin BtcMainNet => new NetworkCoin(BtcSimilarCoin.Btc, BtcSimilarNetwork.Mainnet);
        public static NetworkCoin BtcTestNet => new NetworkCoin(BtcSimilarCoin.Btc, BtcSimilarNetwork.Testnet);
        public static NetworkCoin BchMainNet => new NetworkCoin(BtcSimilarCoin.Bch, BtcSimilarNetwork.Mainnet);
        public static NetworkCoin BchTestNet => new NetworkCoin(BtcSimilarCoin.Bch, BtcSimilarNetwork.Testnet);
        public static NetworkCoin LtcMainNet => new NetworkCoin(BtcSimilarCoin.Ltc, BtcSimilarNetwork.Mainnet);
        public static NetworkCoin LtcTestNet => new NetworkCoin(BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet);
        public static NetworkCoin DashMainNet => new NetworkCoin(BtcSimilarCoin.Dash, BtcSimilarNetwork.Mainnet);
        public static NetworkCoin DashTestNet => new NetworkCoin(BtcSimilarCoin.Dash, BtcSimilarNetwork.Testnet);
        public static NetworkCoin DogeMainNet => new NetworkCoin(BtcSimilarCoin.Doge, BtcSimilarNetwork.Mainnet);
        public static NetworkCoin DogeTestNet => new NetworkCoin(BtcSimilarCoin.Doge, BtcSimilarNetwork.Testnet);
        public static NetworkCoin EthMainNet => new NetworkCoin(EthSimilarCoin.Eth, EthSimilarNetwork.Mainnet);
        public static NetworkCoin EthRinkeby => new NetworkCoin(EthSimilarCoin.Eth, EthSimilarNetwork.Rinkeby);
        public static NetworkCoin EthRopsten => new NetworkCoin(EthSimilarCoin.Eth, EthSimilarNetwork.Ropsten);
        //public static NetworkCoin EtcMainNet => new NetworkCoin(EthSimilarCoin.Etc, EthSimilarNetwork.Mainnet);
        //public static NetworkCoin EtcMorden => new NetworkCoin(EthSimilarCoin.Etc, EthSimilarNetwork.Morden);

        #region IEquatable<MarketCoin>

        public bool Equals(NetworkCoin other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Equals(Coin, other.Coin) && Equals(Network, other.Network);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((NetworkCoin)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Coin != null ? Coin.GetHashCode() : 0) * 397) ^ (Network != null ? Network.GetHashCode() : 0);
            }
        }

        #endregion IEquatable<MarketCoin>
    }
}