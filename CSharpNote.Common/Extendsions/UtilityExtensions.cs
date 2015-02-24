namespace CSharpNote.Common.Extendsions
{
    public static class UtilityExtensions
    {
        public static void Swap(ref int value1 , ref int value2)
        {
            value1 ^= value2;
            value2 ^= value1;
            value1 ^= value2;
        }
    }
}