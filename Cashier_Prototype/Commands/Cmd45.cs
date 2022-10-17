namespace Cashier_Prototype.Commands
{
    /// <summary>預かり金計数開始</summary>
    public class Cmd45 : Command
    {
        protected override byte DH1 { get; } = 0x45;
    }
}