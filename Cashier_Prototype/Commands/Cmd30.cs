namespace Cashier_Prototype.Commands
{
    /// <summary>リセット</summary>
    public class Cmd30 : Command
    {
        protected override byte DH1 { get; } = 0x30;
    }
}
