using System.Text;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class TypeConvert
    {
        private readonly string name;
        //將建構子設為私有，代表無法用new關鍵字new出A型別
        private TypeConvert(string name)
        {
            this.name = "ExampleObj:" + name;
        }

        //隱含轉換
        public static implicit operator TypeConvert(string expandedName)
        {
            return new TypeConvert(expandedName);
        }

        public static implicit operator bool(TypeConvert obj)
        {
            return true;
        }

        //明確轉換
        public static explicit operator TypeConvert(StringBuilder expandedName)
        {
            return new TypeConvert(expandedName.ToString());
        }

        public override string ToString()
        {
            return name;
        }
    }
}