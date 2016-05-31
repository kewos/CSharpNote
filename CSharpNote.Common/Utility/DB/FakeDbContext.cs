using System;
using System.Collections.Generic;

namespace CSharpNote.Common.Utility.DB
{
    /// <summary>
    ///     假的DBSet
    /// </summary>
    public class DbSet<T> : List<T>
    {
    }

    /// <summary>
    ///     假的DBContext
    /// </summary>
    public class FakeDbContext : IDisposable
    {
        private static readonly Dictionary<string, object> dataSet
            = new Dictionary<string, object>();

        public void Dispose()
        {
            //Dispose
        }

        private void Add<T>(string key)
        {
            var dbSet = new DbSet<T>();
            dataSet.Add(key, dbSet);
        }

        public DbSet<T> GetDbSet<T>()
        {
            var key = typeof (T).ToString();
            object value;

            if (!dataSet.TryGetValue(key, out value))
            {
                Add<T>(key);
            }

            return dataSet[key] as DbSet<T>;
        }

        public void SaveChanges()
        {
            //SaveChanges
        }
    }
}