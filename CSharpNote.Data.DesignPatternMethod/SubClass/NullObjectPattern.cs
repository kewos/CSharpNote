using System.Collections.Generic;

namespace CSharpNote.Data.DesignPatternMethod.SubClass
{
    public abstract class ObjectBase
    {
        public virtual string GetTypeName { get { return GetType().Name; } }
        public static NullObject Null { get { return new NullObject(); } }

        public class NullObject : ObjectBase
        {
        }
    }

    public class ObjectA : ObjectBase
    {
    }

    public class ObjectB : ObjectBase
    {
    }

    public class ObjectC : ObjectBase
    {
    }

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
