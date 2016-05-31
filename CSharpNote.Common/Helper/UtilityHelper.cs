namespace CSharpNote.Common.Helper
{
    public static class UtilityHelper
    {
        /// <summary>
        ///     數值交換
        /// </summary>
        public static void Swap(ref int value1, ref int value2)
        {
            value1 ^= value2;
            value2 ^= value1;
            value1 ^= value2;
        }
    }
}