using System.Collections.Generic;

namespace CSharpNote.Data.DesignPattern.Implement.NullObjectPattern
{
    public class ObjectRespository
    {
        public Dictionary<string, ObjectBase> dictionary;

        public ObjectRespository(List<ObjectBase> elements)
        {
            if (dictionary == null)
            {
                dictionary = new Dictionary<string, ObjectBase>();
            }

            elements.ForEach(element => dictionary.Add(element.GetTypeName, element));
        }

        public ObjectBase Find(string typeName)
        {
            return (dictionary.ContainsKey(typeName)) ? dictionary[typeName] : ObjectBase.Null;
        }
    }
}