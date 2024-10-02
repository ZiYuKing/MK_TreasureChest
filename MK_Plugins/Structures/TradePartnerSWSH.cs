using PKHeX.Core;
using System.Diagnostics;

namespace MK_Plugins.Structures;

public sealed class TradePartnerSWSH
{
    public string TID7 { get; }
    public string SID7 { get; }
    public string TrainerName { get; }

    // based on https://github.com/berichan/SysBot.PLA/commit/8196b11a48e66d1ef3fa6c9c8f36c9bcc6cf96e7
    public byte Game { get; }
    public byte Language { get; }
    public byte Gender { get; }

    public ulong NID { get; set; }

    public TradePartnerSWSH(byte[] TIDSID, byte[] trainerNameObject, byte[] idbytes)
    {
        Debug.Assert(TIDSID.Length == 4);
        var tidsid = BitConverter.ToUInt32(TIDSID, 0);
        TID7 = $"{tidsid % 1_000_000:000000}";
        SID7 = $"{tidsid / 1_000_000:0000}";

        TrainerName = StringConverter8.GetString(trainerNameObject);

        Game = idbytes[4];
        Gender = idbytes[6];
        Language = idbytes[5];
    }

    public const int MaxByteLengthStringObject = 0x26;
}
