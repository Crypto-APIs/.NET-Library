using CryptoApisLibrary.DataTypes;

namespace TestCryptoApis
{
    internal static class Features
    {
        public static Exchange Bittrex { get; } = new Exchange("5b1ea9d21090c200146f7366");
        public static Exchange Binance { get; } = new Exchange("5b1ea9d21090c200146f7362");
        public static Exchange Bitstamp { get; } = new Exchange("5b1ea9d21090c200146f7364");
        public static Exchange Poloniex { get; } = new Exchange("5b1ea9d21090c200146f7367");
        public static Exchange UnexistingExchange { get; } = new Exchange("QWE'EWQ");

        public static Asset Btc { get; } = new Asset("5b1ea92e584bf50020130612");
        public static Asset Usd { get; } = new Asset("5b1ea92e584bf50020130615");
        public static Asset Ltc { get; } = new Asset("5b1ea92e584bf50020130616");
        public static Asset Eth { get; } = new Asset("5b755dacd5dd99000b3d92b2");
        public static Asset Dash { get; } = new Asset("5b1ea92e584bf50020130620");
        public static Asset Doge { get; } = new Asset("5b1ea92e584bf50020130626");
        public static Asset Bch { get; } = new Asset("5b1ea92e584bf5002013061c");
        public static Asset UnexistingAsset { get; } = new Asset("QWE'EWQ");

        public static Symbol BtcLtc { get; } = new Symbol { Id = "5bfc325d9c40a100014db900" };
        public static Symbol BtcBch { get; } = new Symbol { Id = "5bfc325f9c40a100014db9b0" };
        public static Symbol UsdBtc { get; } = new Symbol { Id = "5bfc325f9c40a100014db9eb" };
        public static Symbol EthLtc { get; } = new Symbol { Id = "5bfc325e9c40a100014db98b" };
        public static Symbol UnexistingSymbol { get; } = new Symbol { Id = "QWE'EWQ" };

        public static class CorrectBlockHash
        {
            public static string BtcMainNet { get; } = "00000000000000000013dc04902f71e2a4b16d45497eb189beb805e57c5ce1e4";
            public static string BtcTestNet { get; } = "000000000000008fa830e25a3904d5c16a4e3ccee690ce5a7ef8e06237cdf593";
            public static string BchMainNet { get; } = "000000009b7262315dbf071787ad3656097b892abffd1f95a1a022f896f533fc";
            public static string BchTestnet { get; } = "000000000c845bf0cfb24f501db65f171a200c8de126c3c4698688a1128189f9";
            public static string LtcMainNet { get; } = "f69e755922153ae0fa017322a3ee3463558f74b03dc2aed6261ae6f3dcd3dc53";
            public static string LtcTestnet { get; } = "1f2ac66307496209107b7ed45d13423741be50389b718b549f964d8ddcdec0a9";
            public static string DogeMainNet { get; } = "f21dc70cb44c180261e31a222202678602d605e7697332cb2395386fa309ad3b";
            public static string DogeTestnet { get; } = "ea11f3fdb69e2006beb2c951ff6d7ce6e01a599df7f5d8a61c85a75cd4ac5161";
            public static string DashMainNet { get; } = "000000000000000044c74c5c7e0f9258a04eff106fb29bbbf858643a7b4977fd";
            public static string DashTestnet { get; } = "00000b8b8367c820dbf81544c730f158d5c9b2e52a1ce80af99f1c9ef9ca5a38";
            public static string EthMainNet { get; } = "0x0d13e81c01de31060a2830bb53761ef29ac5c4e5c1d43e309ca9a101140e394c";
            public static string EthRopsten { get; } = "0xe82f907c663de3887c4952fde13e57507f79509a73542310fef0eec4ae484762";
            public static string EthRinkenby { get; } = "0x93a4dd08d2f8bfb2f502f9cace4b75f6380f7f283bf3ae62de357c1dceeaec14";
            public static string EtcMainNet { get; } = "0x85e705f42f76436febf004bd0140babba894989b3c7c4e41508947d6050b8026";
            public static string EtcMorden { get; } = "0x70365d87c8f3d01d51feb641ef8fcaa71b366b165b8fb73397b6f3c7d38b5781";
        }

        public static class CorrectBlockHeight
        {
            //public static int BtcMainNet { get; } = ;
            //public static int BtcTestNet { get; } = ;
            //public static int BchMainNet { get; } = ;
            //public static int BchTestnet { get; } = ;
            //public static int LtcMainNet { get; } = ;
            //public static int LtcTestnet { get; } = ;
            //public static int DogeMainNet { get; } = ;
            //public static int DogeTestnet { get; } = ;
            //public static int DashMainNet { get; } = ;
            //public static int DashTestnet { get; } = ;
            public static int EthMainNet { get; } = 6530876;
            public static int EthRopsten { get; } = 4173655;
            public static int EthRinkenby { get; } = 4280114;
            public static int EtcMainNet { get; } = 8654153;
            public static int EtcMorden { get; } = 1885149;
        }
        public static class CorrectAddress
        {
            public static string BtcMainNet { get; } = "1DUb2YYbQA1jjaNYzVXLZ7ZioEhLXtbUru";
            public static string BtcTestNet { get; } = "mho4jHBcrNCncKt38trJahXakuaBnS7LK5";
            public static string BchMainNet { get; } = "bitcoincash:pp8skudq3x5hzw8ew7vzsw8tn4k8wxsqsv0lt0mf3g";
            public static string BchTestNet { get; } = "bchtest:qq22nw9ngfvljcrutymu6553d93342geac4zdqsda4";
            public static string LtcMainNet { get; } = "LKyKfVg4QDSyyraNPhWmVNThbXBfjSaikY";
            public static string LtcTestNet { get; } = "mrkDpF1ZQTGwrbug8eCCHACYTPe2RQSJ3B";
            public static string DogeMainNet { get; } = "9zVT5LTTM1N29Cmb9KEYPzV8nUSn4mYdkk";
            public static string DogeTestNet { get; } = "2MtF65ZhrkqsHsNoFtA91e1AdveqXLMvS5M";
            public static string DashMainNet { get; } = "XfKtLurcoFSVbCVwde8JDAPfX88Ugyo4H4";
            public static string DashTestNet { get; } = "yQgGqVdasi5jGfweJ84HJz4qp4ac5G2gxG";
            public static string EthMainNet { get; } = "0xb794F5eA0ba39494cE839613fffBA74279579268";
            public static string EthRopsten { get; } = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
            public static string EthRinkenby { get; } = "0x54b7bc5bea3845198ff2936761087fc488504eed";
            public static string EtcMainNet { get; } = "0x1c0fa194a9d3b44313dcd849f3c6be6ad270a0a4";
            public static string EtcMorden { get; } = "0x26588a9301b0428d95e6fc3a5024fce8bec12d51";
        }

        public static class CorrectAddress2
        {
            public static string BtcMainNet { get; } = "1B5WsYR8m4axbmEMMifveDL2gtZjtpaFr5";
            public static string BtcTestNet { get; } = "mkU95cnEYqKRb7G9RiLTAP2AbFazUAj2pa";
            public static string BchMainNet { get; } = "bitcoincash:qphghkmf5zym4nwd45d5tagzzut3xpfkp52045tl2j";
            public static string BchTestNet { get; } = "bchtest:qq686unm4724lfjh09p4n30n3k649yj56uvyf54ste";
            public static string LtcMainNet { get; } = "Lad4PXW9HWQctdJVqcC97kSMzRw6iYRSjw";
            public static string LtcTestNet { get; } = "mkY9bvNEiLZCWwhpGiQ3mCBcNXd1DXzE8m";
            public static string DogeMainNet { get; } = "D6n45H31Yr91ZS1KuKGq2tt7uNqVNU3QxJ";
            public static string DogeTestNet { get; } = "2NDutUPDhfMYGUFPhHRy4ZRraHVrEK7odr6";
            public static string DashMainNet { get; } = "XviPbBbm64KJ6Zje8YKQdtj6AmJvFXP3MH";
            public static string DashTestNet { get; } = "yM74nFFXXwMUYXEDhpdNP2PCL6vkdkFhkS";
            public static string EthMainNet { get; } = "0x8683981206d2227ca19bb35d3cade31671eed610";
            public static string EthRopsten { get; } = "0xbD4D8e4be6b70ab33C29759B398c5663D14245D8";
            public static string EthRinkenby { get; } = "0x70432FE7B0D1130DA2e3c22Be4FB7F2ECc2883B3";
            public static string EtcMainNet { get; } = "0xDf7D7e053933b5cC24372f878c90E62dADAD5d42";
            public static string EtcMorden { get; } = "0x91c37bde81ddce4cef1f30528d3c6878e99af338";
        }

        public static class CorrectAddress3
        {
            public static string BtcMainNet { get; } = "1P3t6SKHuymgrs2vvgFvtsmnKen2C8gKU9";
            public static string BtcTestNet { get; } = "muvTWioSTbJWK2HSRGcKoTfT7yDGhgaKso";
            public static string BchMainNet { get; } = "bitcoincash:qr3vzws2wwr3hdwhaxw9edrdscv7west45qel5yxj6";
            public static string BchTestNet { get; } = "bchtest:qpfpec7klx2x2mfn65n873jqcas395y9jcfl64ed4x";
            public static string LtcMainNet { get; } = "LdYmBLEYNHs4XDomUwCHAQi2RNZ61dvu9n";
            public static string LtcTestNet { get; } = "n2ov2TJfLv3vPdU7xZuycpwaJCxtwf2QTJ";
            public static string DogeMainNet { get; } = "D6mpUJucStypmumqPAXGTr5wTS2q1bPScn";
            public static string DogeTestNet { get; } = "2MtyiFTv3aP9uWWeFZxz2hkJL7Dt5FY2LFV";
            public static string DashMainNet { get; } = "XkQXcew87m5FoY7Zuwd81ixkoFPMbYeENo";
            public static string DashTestNet { get; } = "yereyozxENB9jbhqpbg1coE5c39ExqLSaG";
            public static string EthMainNet { get; } = "";
            public static string EthRopsten { get; } = "";
            public static string EthRinkenby { get; } = "";
            public static string EtcMainNet { get; } = "";
            public static string EtcMorden { get; } = "";
        }

        public static class CorrectTransactionHash
        {
            public static string BtcMainNet { get; } = "5a4ebf66822b0b2d56bd9dc64ece0bc38ee7844a23ff1d7320a88c5fdb2ad3e2";
            public static string BtcTestNet { get; } = "fd9896891d9ca6334407d1b20068f3546758d3175177573eade1f47adc58e78a";
            public static string BchMainNet { get; } = "5a4ebf66822b0b2d56bd9dc64ece0bc38ee7844a23ff1d7320a88c5fdb2ad3e2";
            public static string BchTestNet { get; } = "066100ef7304e0467aeac07b8f8866ddb30e6a0b8c935bc79f0870a081a88977";
            public static string LtcMainNet { get; } = "d77cb6b67f4d559d1e74ef400c6f540c90ca89e9abe4efb497fd0e62c5f8e0aa";
            public static string LtcTestNet { get; } = "7872e2e2ddd548b05821e718b88bae9f310bf696dbfe5a82ae2b7b95a70f6501";
            public static string DogeMainNet { get; } = "7ff14bdf13550aa0b1880238ba3f71d21a111810a56b09ea40924da64925128e";
            public static string DogeTestNet { get; } = "2a5a26e9e54bcb83eb5f530caf079ec55b5c9a1720eda17d3e4581f04d5afcb4";
            public static string DashMainNet { get; } = "56f8d56389b62ba7877867c0aa3895810f5c0cb25161a059cb9a4abf338c852b";
            public static string DashTestNet { get; } = "11db543f47f2bf1ab74575634661e6e0a2ec392b4b23ab30c2c27598e4833a75";
            public static string EthMainNet { get; } = "0x5d41df69ee87f712e76ee5f4dd6c0ccbec114b9d871340b7e2b34bf6d8d26c2c";
            public static string EthRopsten { get; } = "0xf81f9d0091d8e424545f080a6cbd1b5167926371f90828292452ca9df90b551e";
            public static string EthRinkenby { get; } = "0x63fb208e2835234aa80efc3ab457ddec121f9fe873a68d487162492a1a32a8a0";
            public static string EtcMainNet { get; } = "0x58576e8e1516697a071b180c7076b4e8906c61620d8916a02b0d5e707cb0f644";
            public static string EtcMorden { get; } = "0x213ed2c788752539e24b56ebcc1dae932717f81e950fccfe485d61b26f3f27ab";
        }
    }
}