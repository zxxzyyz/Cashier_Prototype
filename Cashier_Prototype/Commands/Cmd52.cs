namespace Cashier_Prototype.Commands
{
    /// <summary>締め</summary>
    public class Cmd52 : Command
    {
        protected override byte DH1 { get; } = 0x52;

        /// <summary>処理モード</summary>
        public enum Cm52Config
        {
            /// <summary>交代処理</summary>
            ShiftProcess = 48,
            /// <summary>締め処理</summary>
            CloseProcess
        }

        /// <summary>データ部を設定する</summary>
        /// <param name="value">yyyyMMddhhmmssのフォーマット</param>
        public void SetData(Cm52Config config, string id)
        {
            var temp = new System.Collections.Generic.List<byte>();
            temp.Add(48);
            temp.Add((byte)config);
            for (int i = 0; i < 8; i++)
            {
                if (id.Length > i) temp.Add((byte)id[i]);
                else temp.Add(48);
            }
            temp.Add(48);
            temp.Add(48);
            Data = temp.ToArray();
        }
    }
}
