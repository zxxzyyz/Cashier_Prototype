namespace Cashier_Prototype.Commands
{
    /// <summary>現金戻し開始</summary>
    public class Cmd57 : Command
    {
        protected override byte DH1 { get; } = 0x57;
    }
}