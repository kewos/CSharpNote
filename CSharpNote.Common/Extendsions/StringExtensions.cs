namespace CSharpNote.Common.Extendsions
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string @string)
        {
            var mid = @string.Length / 2;

            for (var i = 0; i < mid; i++)
            {
                if (@string[i] != @string[@string.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}