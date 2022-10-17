namespace Cashier_Prototype.Commands
{
    /// <summary>拡張SSW設定</summary>
    public class Cmd3F : Command
    {
        protected override byte DH1 { get; } = 0x3F;

        public enum Cmd3CConfig
        {
            CoinPart = 48,
            NotePart
        }

        public void SetData(Cmd3CConfig config, int sswNumber, byte data)
        {
            var temp = new System.Collections.Generic.List<byte>();
            temp.Add(48);
            temp.Add((byte)config);
            temp.Add(sswNumber.GetHexAtDigit(2));
            temp.Add(sswNumber.GetHexAtDigit(1));
            temp.Add((byte)(data + 48));
            temp.Add(0);
        }
    }
}
