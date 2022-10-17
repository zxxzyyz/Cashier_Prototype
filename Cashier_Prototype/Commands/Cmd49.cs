namespace Cashier_Prototype.Commands
{
    /// <summary>計数モード設定</summary>
    public class Cmd49 : Command
    {
        protected override byte DH1 { get; } = 0x49;

        /// <summary>設定フラグ</summary>
        public enum Cmd49FlagConfig
        {
            /// <summary>参照</summary>
            Get = 48,
            /// <summary>設定</summary>
            Set
        }

        /// <summary>設定内容</summary>
        public enum Cmd49ModeConfig
        {
            /// <summary>預かり金手入力モード</summary>
            Mode0 = 48,
            /// <summary>預かり金計数モード</summary>
            Mode1,
            /// <summary>現金管理機モード</summary>
            Mode2
        }

        public void SetData(Cmd49FlagConfig flag)
        {
            Data = new byte[] { 48, (byte)flag, 48, 48 };
        }

        public void SetData(Cmd49FlagConfig flag, Cmd49ModeConfig mode)
        {
            Data = new byte[] { 48, (byte)flag, 48, (byte)mode };
        }
    }
}