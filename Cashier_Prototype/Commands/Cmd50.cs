namespace Cashier_Prototype.Commands
{
    /// <summary>ドロアオープン</summary>
    public class Cmd50 : Command
    {
        protected override byte DH1 { get; } = 0x50;

        public void SetData(Cmd50Config config)
        {
            Data = new byte[] { 48, (byte)config };
        }

        /// <summary>包装硬貨部の開許可・禁止設定</summary>
        public enum Cmd50Config
        {
            /// <summary>設定なし</summary>
            NoConfig = 48,
            /// <summary>包装硬貨部開許可</summary>
            Permit,
            /// <summary>包装硬貨部開禁止</summary>
            Prohibit
        }
    }
}
