namespace Cashier_Prototype.Commands
{
    /// <summary>ローカル操作禁止</summary>
    public class Cmd4C : Command
    {
        protected override byte DH1 { get; } = 0x4C;

        /// <summary>ローカル操作の禁止・解除設定</summary>
        public enum Cmd4CConfig
        {
            /// <summary>禁止</summary>
            Lock = 48,
            /// <summary>解除</summary>
            Unlock
        }

        public void SetData(Cmd4CConfig config)
        {
            Data = new byte[] { (byte)config, 48 };
        }
    }
}
