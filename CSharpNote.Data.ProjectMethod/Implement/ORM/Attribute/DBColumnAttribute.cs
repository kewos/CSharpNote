
using System;

namespace CSharpNote.Data.Project.Implement.ORM.Attribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DBColumnAttribute : System.Attribute
    {
        public DBColumnAttribute(string columnName)
        {
            ColumnName = columnName;
        }

        public string ColumnName { get; private set; }
    }
}