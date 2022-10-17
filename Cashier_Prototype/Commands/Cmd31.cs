namespace Cashier_Prototype.Commands
{
    /// <summary>金額指定放出</summary>
    public class Cmd31 : Command
    {
        protected override byte DH1 { get; } = 0x31;

        public Cmd31Format Format { get; private set; } = Cmd31Format.FiveDigit;

        public void SetFormat(Cmd31Format format)
        {
            Format = format;
        }

        /// <summary>データ部フォーマット</summary>
        public enum Cmd31Format
        {
            /// <summary>紙幣つり銭機互換仕様 - 指示金BCD6桁</summary>
            SixDigit,
            /// <summary>紙幣つり銭機互換仕様 - 指示金BCD5桁</summary>
            FiveDigit,
            /// <summary>標準仕様 - 指示金BCD3桁</summary>
            ThreeDigit,
            /// <summary>簡易仕様) - 指示金BCD3桁</summary>
            SimpleThreeDigit
        }

        /// <param name="value">指示金をデータ部のフォーマットに合わせて指定</param>
        public void SetData(string value)
        {
            var tempList = new System.Collections.Generic.List<byte>();
            for (int i = 0; i < value.Length; i++)
            {
                tempList.Add((byte)value[i]);
            }
            Data = tempList.ToArray();
        }

        protected override byte GetBCC()
        {
            byte temp = 0;
            foreach (var item in Data) temp ^= item;
            return temp ^= ETX;
        }

        public override byte[] ToFrame()
        {
            var temp = new System.Collections.Generic.List<byte>();
            temp.Add(STX);
            if (Format != Cmd31Format.SimpleThreeDigit) temp.Add(DC1);
            if (Format != Cmd31Format.SimpleThreeDigit) temp.Add(DH1);  
            if (Format != Cmd31Format.SimpleThreeDigit) temp.Add(GetL1());
            if (Format != Cmd31Format.SimpleThreeDigit) temp.Add(GetL2());
            temp.AddRange(Data);
            temp.Add(ETX);
            if (Format != Cmd31Format.SimpleThreeDigit) temp.Add(base.GetBCC());
            else temp.Add(GetBCC());
            return temp.ToArray();
        }
    }
}
