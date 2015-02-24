using System;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.ObjectPoolPattern
{
    public class PooledObject
    {
        DateTime createdAt = DateTime.Now;

        public DateTime CreatedAt
        {
            get { return createdAt; }
        }

        public string TempData { get; set; }
    }
}