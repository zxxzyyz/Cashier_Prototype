namespace Cashier_Prototype.Commands
{
    /// <summary>取引外出金コマンド(金額指定)</summary>
    public class Cmd55 : Command
    {
        protected override byte DH1 { get; } = 0x55;

        /// <param name="value">指示金額をBCD5桁・BCD6桁で指定</param>
        public void SetData(string value)
        {
            var tempList = new System.Collections.Generic.List<byte>();
            for (int i = 0; i < value.Length; i++)
            {
                tempList.Add((byte)value[i]);
            }
            Data = tempList.ToArray();
        }
    }
}