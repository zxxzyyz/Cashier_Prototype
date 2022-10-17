namespace Cashier_Prototype.Commands
{
    /// <summary>メモリクリア</summary>
    public class Cmd33 : Command
    {
        protected override byte DH1 { get; } = 0x33;

        public void SetData(Cmd33Config config)
        {
            Data = new byte[] { 48, (byte)config };
        }

        /// <summary>クリアするメモリ</summary>
        public enum Cmd33Config
        {
            /// <summary>累積補充枚数、累積抜取りカセット枚数、累積抜取りカセット在高異常フラグ</summary>
            StackMemory = 49,
            /// <summary>前回抜取りカセット枚数、前回抜取りカセット在高異常フラグ</summary>
            LastMemory
        }
    }
}
