namespace Cashier_Prototype.Commands
{
    /// <summary>計数再開</summary>
    public class Cmd48 : Command
    {
        protected override byte DH1 { get; } = 0x48;
    }
}