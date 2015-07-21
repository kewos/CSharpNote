namespace CSharpNote.Common.Extensions
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

        public static string Format(this string format, params string[] items)
        {
            return string.Format(format, items);
        }

        public static bool IsNullOrEmpty(this string target)
        {
            return string.IsNullOrEmpty(target);
        }
    }
}