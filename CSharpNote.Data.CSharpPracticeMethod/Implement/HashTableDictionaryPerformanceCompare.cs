using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class HashTableDictionaryPerformanceCompare : AbstractExecuteModule
    {
        /// <summary>
        ///     HashTableDictionaryPerformanceCompare
        ///     Conclusion:
        ///     Hashtable has less performance than Dictionary because of Boxing and Unboxing.
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            var hashTable = new Hashtable();
            var dictionary = new Dictionary<int, int>();
            var excuteTimes = Enumerable.Range(0, 1000000);
            excuteTimes.ForEach(n =>
            {
                hashTable.Add(n, n);
                dictionary.Add(n, n);
            });

            Action hashTableGetRemoveAction = () =>
            {
                excuteTimes.ForEach(n =>
                {
                    if (hashTable.Contains(n))
                    {
                        var i = (int) hashTable[n];
                        hashTable.Remove(i);
                    }
                });
            };
            hashTableGetRemoveAction.CaculateExcuteTime().ToConsole("hashTable:");

            Action dictionaryGetRemoveAction = () =>
            {
                excuteTimes.ForEach(n =>
                {
                    if (dictionary.ContainsKey(n))
                    {
                        var i = dictionary[n];
                        dictionary.Remove(i);
                    }
                });
            };
            dictionaryGetRemoveAction.CaculateExcuteTime().ToConsole("Dictionary:");
        }
    }
}