using System.Collections.Generic;
using CSharpNote.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Common.Test
{
    [TestClass]
    public class TestDictionaryExtensions
    {
        [TestMethod]
        public void GetValueOrDefault_InputA_OutputA()
        {
            //Arrange
            var dictionary = new Dictionary<string, string>
            {
                {"a", "a"}
            };
            ;

            //Act
            var actual = dictionary.GetValueOrDefault("a");

            //Validation
            var expect = "a";
            Assert.AreEqual(actual, expect);
        }

        [TestMethod]
        public void GetValueOrDefault_InputAAA_OutputNULL()
        {
            //Arrange
            var dictionary = new Dictionary<string, string>
            {
                {"a", "a"}
            };
            ;

            //Act
            var actual = dictionary.GetValueOrDefault("aaa");

            //Validation
            var expect = (string) null;
            Assert.AreEqual(actual, expect);
        }

        [TestMethod]
        public void GetValueOrDefault_Input1_Output0()
        {
            //Arrange
            var dictionary = new Dictionary<int, int>();

            //Act
            var actual = dictionary.GetValueOrDefault(1);

            //Validation
            var expect = 0;
            Assert.AreEqual(actual, expect);
        }

        [TestMethod]
        public void GetValueOrDefault_Input1_Output1()
        {
            //Arrange
            var dictionary = new Dictionary<int, int>
            {
                {1, 1}
            };

            //Act
            var actual = dictionary.GetValueOrDefault(1);

            //Validation
            var expect = 1;
            Assert.AreEqual(actual, expect);
        }
    }
}