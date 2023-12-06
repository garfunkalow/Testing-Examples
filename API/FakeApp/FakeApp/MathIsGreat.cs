namespace FakeApp
{
    public class MathIsGreat : IMath
    {
        public int Add(int first, int second)
        {
            return first + second;
        }

        public uint Subtract(uint first, uint second)
        {
            return first - second;
        }
    }
}