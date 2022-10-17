namespace Cashier_Prototype.Commands
{
    /// <summary>
    /// モード切り換え・累計カウンタクリア
    /// <para><see cref="Cmd36Format.Mode1"/>:モード切り換え</para>
    /// <para><see cref="Cmd36Format.Mode2"/>:累計カウンタクリア</para>
    /// </summary>
    public class Cmd36 : Command
    {
        protected override byte DH1 { get; } = 0x36;

        public Cmd36Format Format { get; set; } = Cmd36Format.Mode1;

        public void SetFormat(Cmd36Format format)
        {
            Format = format;
            if (Format == Cmd36Format.Mode2) { Data = null; }
        }

        /// <summary>データ部フォーマット</summary>
        public enum Cmd36Format
        {
            /// <summary>モード切り換えコマンド</summary>
            Mode1,
            /// <summary>累積カウンタクリアコマンド</summary>
            Mode2
        }

        /// <summary>紙幣部・硬貨部の運用</summary>
        public enum Cmd36Config
        {
            /// <summary>接続</summary>
            Connected,
            /// <summary>切り離し</summary>
            Disconnected
        }

        /// <summary>モード切り換えコマンドのデータ部を設定する</summary>
        /// <param name="note">紙幣部の運用を設定する
        /// <para><see cref="Cmd36Config.Connected"/>：接続</para>
        /// <para><see cref="Cmd36Config.Disconnected"/>：切り離し</para></param>
        /// <param name="coin">硬貨部の運用を設定する
        /// <para><see cref="Cmd36Config.Connected"/>：接続</para>
        /// <para><see cref="Cmd36Config.Disconnected"/>：切り離し</para></param>
        public void SetData(Cmd36Config note, Cmd36Config coin)
        {
            byte temp = 48;
            if (note == Cmd36Config.Disconnected) temp += 2;
            if (coin == Cmd36Config.Disconnected) temp += 1;
            Data = new byte[2] { temp, 48 };
        }
    }
}
