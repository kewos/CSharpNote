using System.Collections.Generic;

namespace CSharpNote.Data.DesignPattern.Implement.ObjectPoolPattern
{
    public static class Pool
    {
        private static readonly List<PooledObject> available = new List<PooledObject>();
        private static readonly List<PooledObject> inUse = new List<PooledObject>();

        public static PooledObject GetObject()
        {
            lock (available)
            {
                PooledObject obj;
                if (available.Count != 0)
                {
                    obj = available[0];
                    inUse.Add(obj);
                    available.RemoveAt(0);
                }
                else
                {
                    obj = new PooledObject();
                    inUse.Add(obj);
                }
                return obj;
            }
        }

        /// <summary>
        ///     清回物件池
        /// </summary>
        public static void ReleaseObject(PooledObject obj)
        {
            CleanUp(obj);
            lock (available)
            {
                available.Add(obj);
                inUse.Remove(obj);
            }
        }

        private static void CleanUp(PooledObject obj)
        {
            obj.TempData = null;
        }
    }
}