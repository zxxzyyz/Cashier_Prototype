namespace Cashier_Prototype.Commands
{
    /// <summary>取引外入金開始</summary>
    public class Cmd54 : Command
    {
        protected override byte DH1 { get; } = 0x54;
    }
}