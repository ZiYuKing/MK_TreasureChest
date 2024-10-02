using System;
using System.Collections.Generic;
namespace MK_Plugins.PulginEnums
{
    public class Trainer
    {
        public string OT_Name { get; set; } = "";
        public uint TID16 { get; set; }
        public uint SID16 { get; set; }
        public int Gender { get; set; }
        public int Language { get; set; }
        public int Versions { get; set; }

        public static Trainer ConvertToTrainer(string T)
        {
            string[] str;
            str = T.Split(',');
            Trainer tr = new()
            {
                OT_Name = str[0],
                TID16 = Convert.ToUInt32(str[1]),
                SID16 = Convert.ToUInt32(str[2]),
                Gender = Convert.ToInt32(str[3]),
                Language = Convert.ToInt32(str[4]),
                Versions = Convert.ToInt32(str[5]),
            };
            return tr;
        }

    }
}
