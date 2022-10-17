namespace Cashier_Prototype.Commands
{
    /// <summary>状態リード</summary>
    public class Cmd3B : Command
    {
        protected override byte DH1 { get; } = 0x3B;

        public void SetData(int number)
        {
            Data = new byte[] { number.GetByteAtDigit(2), number.GetByteAtDigit(1) };
        }
    }
}
