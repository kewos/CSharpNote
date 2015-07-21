using System.Collections.Generic;
using CSharpNote.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Common.Test
{
    [TestClass]
    public class Test_DictionaryExtensions
    {
        [TestMethod]
        public void GetValueOrDefault()
        {
            var dictionary = new Dictionary<string, string>
            {
                {"a", "a"},
                {"b", "b"},
                {"c", "c"},
                {"d", "d"},
                {"e", "e"},
            };

            Assert.AreEqual(
                "a", 
                dictionary.GetValueOrDefault("a"));

            Assert.AreEqual(
                null, 
                dictionary.GetValueOrDefault("aaa"));
            
            Assert.AreEqual(
                0, 
                new Dictionary<int, int>().GetValueOrDefault(1));
            
            Assert.AreEqual(
                1, 
                new Dictionary<int, int>{ {1, 1} }.GetValueOrDefault(1));
        }
    }
}