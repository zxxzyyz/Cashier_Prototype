namespace Cashier_Prototype.Commands
{
    /// <summary>回収</summary>
    public class Cmd38 : Command
    {
        protected override byte DH1 { get; } = 0x38;

        /// <summary>紙幣回収モード</summary>
        public enum Cmd38NoteConfig
        {
            /// <summary>指示なし</summary>
            Mode0 = 48,
            /// <summary>千円収納部＋カセット+RJ 部の紙幣を回収</summary>
            Mode1,
            /// <summary>五千円収納部＋カセット+RJ 部の紙幣を回収</summary>
            Mode2,
            /// <summary>全紙幣を回収</summary>
            Mode3,
            /// <summary>残置回収として回収</summary>
            Mode4,
            /// <summary>カセット+RJ 部の紙幣を回収</summary>
            Mode5,
            /// <summary>データ部により指定された枚数＋カセット+RJ 部の紙幣を回収</summary>
            Mode6,
            /// <summary>万円収納部＋カセット+RJ 部の紙幣を回収</summary>
            Mode7,
            /// <summary>二千円収納部＋カセット+RJ 部の紙幣を回収</summary>
            Mode8
        }

        /// <summary>硬貨回収モード</summary>
        public enum Cmd38CoinConfig
        {
            /// <summary>指示なし</summary>
            Mode0 = 48,
            /// <summary>５００円収納部の硬貨を回収</summary>
            Mode1,
            /// <summary>１００円収納部の硬貨を回収</summary>
            Mode2,
            /// <summary>５０円収納部の硬貨を回収</summary>
            Mode3,
            /// <summary>１０円収納部の硬貨を回収</summary>
            Mode4,
            /// <summary>５円収納部の硬貨を回収</summary>
            Mode5,
            /// <summary>１円収納部の硬貨を回収</summary>
            Mode6,
            /// <summary>全収納硬貨を回収</summary>
            Mode7,
            /// <summary>残置回収として回収</summary>
            Mode8,
            /// <summary>データ部により指定された枚数を回収</summary>
            Mode9,
            /// <summary>簡易回収</summary>
            Mode10
        }

        public void SetData(Cmd38NoteConfig note, Cmd38CoinConfig coin, int yen1, int yen5, int yen10, int yen50, int yen100, int yen500, int yen1000, int yen2000, int yen5000, int yen10000)
        {
            var temp = new System.Collections.Generic.List<byte>();
            temp.Add((byte)note);
            temp.Add((byte)coin);
            temp.Add(yen2000.GetByteAtDigit(3));
            temp.Add(yen2000.GetByteAtDigit(2));
            temp.Add(yen2000.GetByteAtDigit(1));
            temp.Add(yen10000.GetByteAtDigit(3));
            temp.Add(yen10000.GetByteAtDigit(2));
            temp.Add(yen10000.GetByteAtDigit(1));
            temp.Add(yen5000.GetByteAtDigit(3));
            temp.Add(yen5000.GetByteAtDigit(2));
            temp.Add(yen5000.GetByteAtDigit(1));
            temp.Add(yen1000.GetByteAtDigit(3));
            temp.Add(yen1000.GetByteAtDigit(2));
            temp.Add(yen1000.GetByteAtDigit(1));
            temp.Add(yen500.GetByteAtDigit(3));
            temp.Add(yen500.GetByteAtDigit(2));
            temp.Add(yen500.GetByteAtDigit(1));
            temp.Add(yen100.GetByteAtDigit(3));
            temp.Add(yen100.GetByteAtDigit(2));
            temp.Add(yen100.GetByteAtDigit(1));
            temp.Add(yen50.GetByteAtDigit(3));
            temp.Add(yen50.GetByteAtDigit(2));
            temp.Add(yen50.GetByteAtDigit(1));
            temp.Add(yen10.GetByteAtDigit(3));
            temp.Add(yen10.GetByteAtDigit(2));
            temp.Add(yen10.GetByteAtDigit(1));
            temp.Add(yen5.GetByteAtDigit(3));
            temp.Add(yen5.GetByteAtDigit(2));
            temp.Add(yen5.GetByteAtDigit(1));
            temp.Add(yen1.GetByteAtDigit(3));
            temp.Add(yen1.GetByteAtDigit(2));
            temp.Add(yen1.GetByteAtDigit(1));
            Data = temp.ToArray();
        }
    }
}
