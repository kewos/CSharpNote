using System;
using System.Collections.Generic;

namespace CSharpNote.Data.DesignPatternMethod.Implement.StretagyPattern
{
    public class StrategyFactory
    {
        private static readonly Dictionary<Type, StrategyBase> strategyPool = new Dictionary<Type, StrategyBase>();

        public static TStrategy Create<TStrategy>() 
            where TStrategy : StrategyBase, new()
        {
            var type = typeof(TStrategy);

            if (!strategyPool.ContainsKey(type))
            {
                strategyPool.Add(type, new TStrategy());
            }

            return strategyPool[type] as dynamic;
        }
    }
}
