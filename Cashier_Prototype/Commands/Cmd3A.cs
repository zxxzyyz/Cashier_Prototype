namespace Cashier_Prototype.Commands
{
    /// <summary>ＳＳＷ設定</summary>
    public class Cmd3A : Command
    {
        protected override byte DH1 { get; } = 0x31;

        public enum Cmd3AConfig
        {
            CoinPart = 48,
            NotePart
        }

        public void SetData(Cmd3AConfig config, int sswNumber, byte data1, byte data2)
        {
            var temp = new System.Collections.Generic.List<byte>();
            temp.Add(48);
            temp.Add((byte)config);
            temp.Add(sswNumber.GetHexAtDigit(2));
            temp.Add(sswNumber.GetHexAtDigit(1));
            temp.Add((byte)(data1 + 48));
            temp.Add((byte)(data2 + 48));
        }
    }
}
