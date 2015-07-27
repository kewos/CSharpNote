using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Extensions;

namespace CSharpNote.Data.DesignPatternMethod.Implement.BuilderPattern
{
    public abstract class BuilderBase<T> : IBuilder<T>
        where T : class
    {
        private readonly IDictionary<string, object> propertyPool;

        protected BuilderBase()
            : this(typeof(T).GetProperties().ToDictionary(p => p.Name, p => default(object)))
        {
        }

        protected BuilderBase(IDictionary<string, object> propertyPool)
        {
            this.propertyPool = propertyPool;
        }

        public virtual BuilderBase<T> Add(string key, object obj)
        {
            if (propertyPool.ContainsKey(key))
            {
                propertyPool.AddOrReplace(key, obj);
            }
            return this;
        }

        public virtual T Create()
        {
            if (!CanCreate())
            {
                throw new ArgumentException("參數不足");
            }

            var instance = Activator.CreateInstance<T>();
            foreach (var property in typeof(T).GetProperties())
            {
                object value;
                if (propertyPool.TryGetValue(property.Name, out value))
                {
                    property.SetValue(instance, value);
                }
            }

            return instance;
        }

        public bool CanCreate()
        {
            return propertyPool.All(p => p.Key != null);
        }
    }
}