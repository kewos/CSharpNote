
using System;

namespace CSharpNote.Data.Project.Implement.ORM.Attribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DbColumnAttribute : System.Attribute
    {
        public DbColumnAttribute(string columnName)
        {
            ColumnName = columnName;
        }

        public string ColumnName { get; private set; }
    }
}