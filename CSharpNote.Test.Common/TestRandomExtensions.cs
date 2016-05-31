using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Common.Test
{
    internal enum TestEnum
    {
        A,
        B,
        C
    }

    [TestClass]
    public class TestRandomExtensions
    {
        private Random NewRandom
        {
            get { return new Random(); }
        }

        [TestMethod]
        public void NextBoolean_InputRandom_ReturnBoolean()
        {
            //Arrange
            var random = NewRandom;

            //Act
            var result = Enumerable.Range(1, 1000).Select(n => random.NextBoolean()).Distinct().ToList();
            var actual = result.All(x => x is bool);

            //Validation
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void RandomOne_InputRandom_ReturnRandomItem()
        {
            //Arrange
            var random = NewRandom;

            //Act
            var result = Enumerable.Range(1, 1000).Select(n => random.RandomOne("A", "B", "C")).Distinct().ToList();
            var set = new List<string> {"A", "B", "C"};
            var actual = result.All(x => set.Contains(x));

            //Validation
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void NextEnum_InputRandom_ReturnRandomEnum()
        {
            //Arrange
            var random = NewRandom;

            //Act
            var result = Enumerable.Range(1, 100).Select(n => random.NextEnum<TestEnum>()).Distinct().ToList();
            var set = new List<TestEnum> {TestEnum.A, TestEnum.B, TestEnum.C};
            var actual = result.All(x => set.Contains(x));

            //Validation
            Assert.IsTrue(actual);
        }
    }
}