namespace System.Linq
{
    public static partial class Enumerable
    {
        private static void ThrowNoElements()
        {
            throw new InvalidOperationException("Enumerable contains no elements");
        }

        private static void ThrowNoMatches()
        {
            throw new InvalidOperationException("Enumerable contains no matching element");
        }
    }
}