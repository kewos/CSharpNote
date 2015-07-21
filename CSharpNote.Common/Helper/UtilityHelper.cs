namespace CSharpNote.Common.Helper
{
    public static class UtilityHelper
    {
        public static void Swap(ref int value1 , ref int value2)
        {
            value1 ^= value2;
            value2 ^= value1;
            value1 ^= value2;
        }
    }
}