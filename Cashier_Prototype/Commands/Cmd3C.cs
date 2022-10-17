namespace Cashier_Prototype.Commands
{
    /// <summary>補充枚数取得</summary>
    public class Cmd3C : Command
    {
        protected override byte DH1 { get; } = 0x3C;

        public enum Cmd3CConfig
        {
            Get = 48,
            GetAndClear
        }

        public void SetData(Cmd3CConfig config)
        {
            Data = new byte[] { 48, (byte)config };
        }
    }
}
