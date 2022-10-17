namespace Cashier_Prototype.Commands
{
    /// <summary>日時設定</summary>
    public class Cmd37 : Command
    {
        protected override byte DH1 { get; } = 0x37;

        /// <summary>日時を設定する</summary>
        /// <param name="value">yyMMddhhmmssのフォーマット</param>
        public void SetData(string value)
        {
            var temp = new System.Collections.Generic.List<byte>();
            temp.AddEachChar(value, value.Length, true, true);
            Data = temp.ToArray();
        }
    }
}
