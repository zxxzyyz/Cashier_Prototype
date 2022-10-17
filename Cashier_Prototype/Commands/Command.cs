namespace Cashier_Prototype.Commands
{
    public abstract class Command
    {
        protected byte STX = 0x02;

        protected byte DC1 = 0x11;

        protected byte ETX = 0x03;

        protected abstract byte DH1 { get; }

        protected byte[] Data { get; set; } = null;

        protected virtual byte GetL1()
        {
            return Data == null ? (byte)0x30 : (byte)(0x30 + (Data.Length / 16));
        }

        protected virtual byte GetL2()
        {
            return Data == null ? (byte)0x30 : (byte)(0x30 + (Data.Length % 16));
        }

        protected virtual byte GetBCC()
        {
            if (Data == null) return (byte)(DC1 ^ DH1 ^ GetL1() ^ GetL2() ^ ETX);
            else
            {
                var temp = (byte)(DC1 ^ DH1 ^ GetL1() ^ GetL2());
                foreach (var item in Data) temp ^= item;
                return temp ^= ETX;
            }
        }

        public virtual byte[] ToFrame()
        {
            var temp = new System.Collections.Generic.List<byte>();
            temp.Add(STX);
            temp.Add(DC1);
            temp.Add(DH1);
            temp.Add(GetL1());
            temp.Add(GetL2());
            if (Data != null) temp.AddRange(Data);
            temp.Add(ETX);
            temp.Add(GetBCC());
            return temp.ToArray();
        }

    }
}
