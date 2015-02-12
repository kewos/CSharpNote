using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Extendsions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Test.Common
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

            //Assert
            var expect = new List<int> {2, 3, 4, 5, 6};
            for (var i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(expect[i], actual[i]);
            }
        }

        [TestMethod]
        public void ForEach_InputNullFunc_ThrowArgumentException()
        {
            //Arrange
            var elements = Enumerable.Range(1, 5);

            //Act
            try
            {
                var actual = elements.ForEach((Func<int, int>)null).ToList();
                Assert.Fail("ExceptionMustBeThrown");
            }
            //Assert
            catch (ArgumentException e)
            {
            }
            catch (Exception e)
            {
                Assert.Fail("IncorrectException");
            }
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

            //Assert
            var expect = new List<int> {1, 2, 3, 4, 5};
            for (var i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(expect[i], actual[i]);
            }
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

            //Assert
            var expect = new Dictionary<int, int>
            {
                {0, 1},
                {1, 2},
                {2, 3},
                {3, 4},
                {4, 5},
            };
            for (var i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(expect[i], actual[i]);
            }
        }

        [TestMethod]
        public void All_InputFuncWithIndex_OutputTrue()
        {
            //Arrange
            var elements = Enumerable.Range(1, 5);

            //Act
            var checkElements = Enumerable.Range(1, 5).ToList();
            var actual = elements.All((index, n) => n == checkElements[index]);

            //Assert
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

            //Assert
            Assert.IsFalse(actual);
        }
    }
}