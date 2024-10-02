namespace MK_Plugins.Structures
{
    internal class Offsets
    {
        #region 朱紫
        public const string ScarletID = "0100A3D008C5C000";
        public const string VioletID = "01008F6008C5E000";
        public static IReadOnlyList<long> BoxStartPokemonPointer_SV { get; } = new long[] { 0x47350D8, 0xD8, 0x8, 0xB8, 0x30, 0x9D0, 0x0 };//需要更新指针的地方1:盒子开始宝可梦指针
        public static IReadOnlyList<long> MyStatusPointer_SV { get; } = new long[] { 0x47350D8, 0xD8, 0x8, 0xB8, 0x0, 0x40 };
        public static IReadOnlyList<long> Trader1MyStatusPointer_SV { get; } = new long[] { 0x473A110, 0x48, 0xB0, 0x0 };
        public static IReadOnlyList<long> Trader2MyStatusPointer_SV { get; } = new long[] { 0x473A110, 0x48, 0xE0, 0x0 };
        public static IReadOnlyList<long> LinkTradePartnerNIDPointer_SV { get; } = new long[] { 0x475EA28, 0xF8, 0x8 };
        public static IReadOnlyList<long> KeyboardBufferPointer_SV { get; } = new long[] { 0x461D0A8, 0x30, 0x00 };
        public static IReadOnlyList<long> LinkTradePartnerPokemonPointer_SV { get; } = new long[] { 0x473A110, 0x48, 0x58, 0x40, 0x148 };
        public static IReadOnlyList<long> PokePortalPointer_SV { get; } = new long[] { 0x4691558, 0x00, 0x3C0, 0x3C0, 0x598 };
        public static IReadOnlyList<long> OverworldPointer_SV { get; } = new long[] { 0x473ADE0, 0x160, 0xE8, 0x28 };
        public static IReadOnlyList<long> PortalBoxStatusPointer_SV { get; } = new long[] { 0x475A0D0, 0x188, 0x350, 0xF0, 0x140, 0x78 };
        public static IReadOnlyList<long> IsConnectedPointer_SV { get; } = new long[] { 0x4763E08, 0x10 };
        public const ulong LibAppletWeID = 0x010000000000100a;
        public static ulong MyNIDPointer_SV { get; } = 0x0475E938; // MyNid
        #endregion

        #region 珍珠钻石
        public const string ShiningPearlID = "010018E011D92000";
        public const string BrilliantDiamondID = "0100000011D90000";
        //珍珠
        public static IReadOnlyList<long> MyStatusTrainerPointer_BS_SP { get; } = new long[] { 0x4E7BE98, 0xB8, 0x10, 0xE0, 0x0 };
        public static IReadOnlyList<long> MyStatusTIDPointer_BS_SP { get; } = new long[] { 0x4E7BE98, 0xB8, 0x10, 0xE8 };
        public static IReadOnlyList<long> ConfigLanguagePointer_BS_SP { get; } = new long[] { 0x4E7BE98, 0xB8, 0x10, 0xAC };
        public static IReadOnlyList<long> LinkTradePartnerNamePointer_BS_SP { get; } = new long[] { 0x4E7C9A8, 0xB8, 0x30, 0x110, 0x28, 0x90, 0x20, 0x0 };
        public static IReadOnlyList<long> LinkTradePartnerIDPointer_BS_SP { get; } = new long[] { 0x4E7C9A8, 0xB8, 0x30, 0x110, 0x28, 0x90, 0x10 };
        public static IReadOnlyList<long> LinkTradePartnerNIDPointer_BS_SP { get; } = new long[] { 0x4FFE810, 0x70, 0x168, 0x40 };
        public static IReadOnlyList<long> LinkTradePartnerPokemonPointer_BS_SP { get; } = new long[] { 0x4C603B0, 0xB8, 0x8, 0x20 };
        public static IReadOnlyList<long> LinkTradePartnerLanguagePointer_BS_SP { get; } = new long[] { 0x4E771F0, 0xC18, 0x498, 0x68, 0x3F };
        public static IReadOnlyList<long> LinkTradePartnerVersionPointer_BS_SP { get; } = new long[] { 0x4E771F0, 0xC18, 0x498, 0x68, 0x3E };
        //钻石
        public static IReadOnlyList<long> MyStatusTrainerPointer_BS_BD { get; } = new long[] { 0x4C64DC0, 0xB8, 0x10, 0xE0, 0x0 };
        public static IReadOnlyList<long> MyStatusTIDPointer_BS_BD { get; } = new long[] { 0x4C64DC0, 0xB8, 0x10, 0xE8 };
        public static IReadOnlyList<long> ConfigLanguagePointer_BS_BD { get; } = new long[] { 0x4C64DC0, 0xB8, 0x10, 0xAC };
        public static IReadOnlyList<long> LinkTradePartnerNamePointer_BS_BD { get; } = new long[] { 0x4C658D0, 0xB8, 0x30, 0x110, 0x28, 0x90, 0x20, 0x0 };
        public static IReadOnlyList<long> LinkTradePartnerIDPointer_BS_BD { get; } = new long[] { 0x4C658D0, 0xB8, 0x30, 0x110, 0x28, 0x90, 0x10 };
        public static IReadOnlyList<long> LinkTradePartnerNIDPointer_BS_BD { get; } = new long[] { 0x4FFE810, 0x70, 0x168, 0x40 };
        public static IReadOnlyList<long> LinkTradePartnerPokemonPointer_BS_BD { get; } = new long[] { 0x4E77488, 0xB8, 0x8, 0x20 };
        public static IReadOnlyList<long> LinkTradePartnerLanguagePointer_BS_BD { get; } = new long[] { 0x4AEBAC8, 0x700, 0x7E8, 0x3F };
        public static IReadOnlyList<long> LinkTradePartnerVersionPointer_BS_BD { get; } = new long[] { 0x4AEBAC8, 0x700, 0x7E8, 0x3E };
        #endregion

        #region 阿尔宙斯
        public const string LegendsArceusID = "01001F5010DFA000";
        public static IReadOnlyList<long> MyStatusPointer_LA { get; } = new long[] { 0x42BA6B0, 0x218, 0x68 };
        public static IReadOnlyList<long> LinkTradePartnerNIDPointer_LA { get; } = new long[] { 0x42EA508, 0xE0, 0x8 };
        public static IReadOnlyList<long> LinkTradePartnerTIDPointer_LA { get; } = new long[] { 0x42ED070, 0xC8, 0x78 };
        public static IReadOnlyList<long> LinkTradePartnerNamePointer_LA { get; } = new long[] { 0x42ED070, 0xC8, 0x88 };
        #endregion

        #region 剑盾
        public const string SwordID = "0100ABF008968000";
        public const string ShieldID = "01008DB008C2C000";
        public const uint TrainerDataOffset_SWSH = 0x45068F18;
        public const uint LinkTradePartnerNIDOffset_SWSH = 0xAF2846B0;
        public const uint LinkTradePartnerNameOffset_SWSH = 0xAF28384C;
        public const uint IsConnectedOffset_SWSH = 0x30c7cca8;
        public const uint LinkTradeSearchingOffset_SWSH = 0x2F76C3C8;
        public const uint SurpriseTradeSearchOffset_SWSH = 0x45067704;
        public const uint LinkTradePartnerPokemonOffset_SWSH = 0xAF286078;
        public const uint CurrentScreenOffset = 0x6B30FA00;
        public const uint CurrentScreen_Box1 = 0xFF00D59B;
        public const uint CurrentScreen_Box2 = 0xFF000000;
        public static IReadOnlyList<long> OverworldPointer_SWSH { get; } = new long[] { 0x2636678, 0xC0, 0x80 };

        public const int TrainerDataLength_SWSH = 0x110;
        #endregion

        #region 去皮去伊
        public const string LetsGoPikachuID = "010003F003A34000";
        public const string LetsGoEeveeID = "0100187003A36000";
        public const uint TrainerData_LGPE = 0x53582030;
        public const uint TradePartnerData_LGPE = 0x41A28240;
        public const uint TradePartnerData2_LGPE = 0x41A28078;

        public const int TrainerSize_LGPE = 0x168;
        #endregion
    }
}
