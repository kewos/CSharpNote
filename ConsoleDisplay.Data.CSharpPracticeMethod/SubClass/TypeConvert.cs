using System.Text;

namespace ConsoleDisplay.Data.CSharpPracticeMethod.SubClass
{
    public class TypeConvert
    {
        private string _name;

        //將建構子設為私有，代表無法用new關鍵字new出A型別
        private TypeConvert(string name)
        {
            _name = "ExampleObj:" + name;
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
            return _name;
        }
    }
}
