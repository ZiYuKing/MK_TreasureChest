using PKHeX.Core;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Text;

namespace MK_Plugins.Structures;

public sealed class TradePartnerSV
{
    public uint IDHash { get; }

    public int TID7 { get; }
    public int SID7 { get; }

    public string TID { get; }
    public string SID { get; }
    public string TrainerName { get; set; }

    public byte Game { get; }
    public byte Language { get; }
    public byte Gender { get; }

    public ulong NSAID { get; set; }

    public TradePartnerSV()
    {
        TID = string.Empty;
        SID = string.Empty;
        TrainerName = string.Empty;
    }
    public TradePartnerSV(byte[] TIDSID, byte[] idbytes, byte[] trainerNameObject)
    {
        Debug.Assert(TIDSID.Length == 4);
        IDHash = BitConverter.ToUInt32(TIDSID, 0);
        TID7 = (int)Math.Abs(IDHash % 1_000_000);
        SID7 = (int)Math.Abs(IDHash / 1_000_000);
        TID = $"{TID7:000000}";
        SID = $"{SID7:0000}";

        Game = idbytes[0];
        Gender = idbytes[1];
        Language = idbytes[3];

        TrainerName = Encoding.Unicode.GetString(trainerNameObject).TrimEnd('\0');
    }
}

public sealed class TradeMyStatusSV
{
    public readonly byte[] Data = new byte[0x30];

    public uint DisplaySID => BinaryPrimitives.ReadUInt32LittleEndian(Data.AsSpan(0)) / 1_000_000;
    public uint DisplayTID => BinaryPrimitives.ReadUInt32LittleEndian(Data.AsSpan(0)) % 1_000_000;

    public int Game => Data[4];
    public int Gender => Data[5];
    public int Language => Data[6];

    public string OT => StringConverter8.GetString(Data.AsSpan(8, 24));
}
