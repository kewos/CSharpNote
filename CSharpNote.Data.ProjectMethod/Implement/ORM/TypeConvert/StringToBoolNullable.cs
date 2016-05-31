namespace CSharpNote.Data.Project.Implement.ORM.TypeConvert
{
    /// <summary>
    ///     字串轉bool?
    /// </summary>
    public class StringToBoolNullable : IStringConvert<bool?>
    {
        public bool? Convert(string input)
        {
            bool value;
            if (bool.TryParse(input, out value))
            {
                return value;
            }
            return null;
        }
    }
}