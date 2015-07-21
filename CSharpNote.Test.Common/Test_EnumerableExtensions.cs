using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Extensions;
using CSharpNote.Common.Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Common.Test
{
    [TestClass]
    public class Test_EnumerableExtensions
    {
        [TestMethod]
        public void ForEach_InputFunc_ReturnExecuteResult()
        {
            //Arrange
            var elements = Enumerable.Range(1, 5);

            //Act
            var actual = elements.ForEach(n => n + 1).ToList();

            //Validation
            var expect = new List<int> {2, 3, 4, 5, 6};
            Assert.IsTrue(actual.SequenceEqual(expect));
        }

        [TestMethod]
        public void ForEach_InputNullFunc_ThrowArgumentException()
        {
            Action action = () => Enumerable.Range(1, 5).ForEach((Func<int, int>)null).ToList();
            action.AssertHandleException<ArgumentException>();
        }

        [TestMethod]
        public void ForEach_InputAction_ExecuteAction()
        {
            //Arrange
            var elements = Enumerable.Range(1, 5);

            //Act
            var actual = new List<int>();
            elements.ForEach(n =>
            {
                actual.Add(n);
            });

            //Validation
            var expect = new List<int> {1, 2, 3, 4, 5};
            Assert.IsTrue(actual.SequenceEqual(expect));
        }

        [TestMethod]
        public void ForEach_InputActionWithIndex_ExecuteAction()
        {
            //Arrange
            var elements = Enumerable.Range(1, 5);

            //Act
            var actual = new Dictionary<int, int>();
            elements.ForEach((index, n) =>
            {
                actual.Add(index, n);
            });

            //Validation
            var expect = new Dictionary<int, int>
            {
                {0, 1},
                {1, 2},
                {2, 3},
                {3, 4},
                {4, 5},
            };
            Assert.IsTrue(actual.SequenceEqual(expect));
        }

        [TestMethod]
        public void All_InputFuncWithIndex_OutputTrue()
        {
            //Arrange
            var elements = Enumerable.Range(1, 5);

            //Act
            var checkElements = Enumerable.Range(1, 5).ToList();
            var actual = elements.All((index, n) => n == checkElements[index]);

            //Validation
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void All_InputFuncWithIndex_OutputFalse()
        {
            //Arrange
            var elements = Enumerable.Range(1, 5);

            //Act
            var checkElements = Enumerable.Range(0, 5).ToList();
            var actual = elements.All((index, n) => n == checkElements[index]);

            //Validation
            Assert.IsFalse(actual);
        }
    }
}