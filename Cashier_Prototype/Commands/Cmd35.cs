namespace Cashier_Prototype.Commands
{
    /// <summary>枚数指定放出</summary>
    public class Cmd35 : Command
    {
        protected override byte DH1 { get; } = 0x35;

        /// <summary>データ部フォーマット</summary>
        public enum Cmd35Format
        {
            /// <summary>2桁で500,100,50,10,5,1のフォーマット</summary>
            TwelveBytes,
            /// <summary>2桁で2000,10000,5000,1000,500,100,50,10,5,1のフォーマット</summary>
            TwentyBytes,
            /// <summary>3桁で2000,10000,5000,1000,500,100,50,10,5,1のフォーマット</summary>
            ThirtyBytes
        }

        public void SetData(Cmd35Format format, int yen1, int yen5, int yen10, int yen50, int yen100, int yen500, int yen1000 = 0, int yen2000 = 0, int yen5000 = 0, int yen10000 = 0)
        {
            var temp = new System.Collections.Generic.List<byte>();
            if (format == Cmd35Format.TwelveBytes)
            {
                temp.Add(yen500.GetByteAtDigit(2));
                temp.Add(yen500.GetByteAtDigit(1));
                temp.Add(yen100.GetByteAtDigit(2));
                temp.Add(yen100.GetByteAtDigit(1));
                temp.Add(yen50.GetByteAtDigit(2));
                temp.Add(yen50.GetByteAtDigit(1));
                temp.Add(yen10.GetByteAtDigit(2));
                temp.Add(yen10.GetByteAtDigit(1));
                temp.Add(yen5.GetByteAtDigit(2));
                temp.Add(yen5.GetByteAtDigit(1));
                temp.Add(yen1.GetByteAtDigit(2));
                temp.Add(yen1.GetByteAtDigit(1));
            }
            if (format == Cmd35Format.TwentyBytes)
            {
                temp.Add(yen2000.GetByteAtDigit(2));
                temp.Add(yen2000.GetByteAtDigit(1));
                temp.Add(yen10000.GetByteAtDigit(2));
                temp.Add(yen10000.GetByteAtDigit(1));
                temp.Add(yen5000.GetByteAtDigit(2));
                temp.Add(yen5000.GetByteAtDigit(1));
                temp.Add(yen1000.GetByteAtDigit(2));
                temp.Add(yen1000.GetByteAtDigit(1));
                temp.Add(yen500.GetByteAtDigit(2));
                temp.Add(yen500.GetByteAtDigit(1));
                temp.Add(yen100.GetByteAtDigit(2));
                temp.Add(yen100.GetByteAtDigit(1));
                temp.Add(yen50.GetByteAtDigit(2));
                temp.Add(yen50.GetByteAtDigit(1));
                temp.Add(yen10.GetByteAtDigit(2));
                temp.Add(yen10.GetByteAtDigit(1));
                temp.Add(yen5.GetByteAtDigit(2));
                temp.Add(yen5.GetByteAtDigit(1));
                temp.Add(yen1.GetByteAtDigit(2));
                temp.Add(yen1.GetByteAtDigit(1));
            }
            if (format == Cmd35Format.ThirtyBytes)
            {
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
            }
            Data = temp.ToArray();
        }
    }
}
