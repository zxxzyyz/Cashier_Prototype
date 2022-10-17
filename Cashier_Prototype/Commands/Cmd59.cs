namespace Cashier_Prototype.Commands
{
    /// <summary>交代データリード</summary>
    public class Cmd59 : Command
    {
        protected override byte DH1 { get; } = 0x59;

        /// <summary>データ部を設定する</summary>
        /// <param name="index">参照データのインデックスを指定する
        /// <para>０：現在データ</para>
        /// <para>１：前回交代データ</para>
        /// <para>２～２３：過去の交代データ</para></param>
        public void SetData(int index)
        {
            Data = new byte[] { index.GetHexAtDigit(2), index.GetHexAtDigit(1) };
        }
    }
}