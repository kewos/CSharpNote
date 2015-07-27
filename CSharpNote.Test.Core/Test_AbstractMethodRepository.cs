using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Core.Implements;
using CSharpNote.Common.Attributes.AopDecorator;
using CSharpNote.Common.Extension;

namespace CSharpNote.Core.Test
{
    [TestClass]
    public class Test_AbstractMethodRepository
    {
        [MarkedRepositoryAttribue]
        private class testMethodRepository : AbstractMethodRepository
        {
            [MarkedItem]
            public void Test1()
            {
            }

            [MarkedItem]
            public void Test2()
            {
            }

            [MarkedItem]
            public void Test3()
            {
            }
        }

        private AbstractMethodRepository TestMethodRepository
        {
            get
            {
                return new testMethodRepository();
            }
        }

        [MarkedRepositoryAttribue]
        private class testMethodRepositories : AbstractMethodRepository
        {
        }

        private AbstractMethodRepository TestMethodRepositories
        {
            get
            {
                return new testMethodRepositories();
            }
        }

        [TestMethod]
        public void RepositoryName_InvalidRepositoryName_ThrowArgumentException()
        {
            Action action = () =>
            {
                var name = TestMethodRepositories.RepositoryName;
            };

            action.AssertHandleException<ArgumentException>();
        }

        [TestMethod]
        public void RepositoryName_Get_ReturnRepositoryName()
        {
            //Arrange
            var repository = TestMethodRepository;

            //Act
            var actual = repository.RepositoryName;

            //Validation
            var expect = "test";
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Count_Get_ReturnRepositoryCount()
        {
            //Arrange
            var repository = TestMethodRepository;

            //Act
            var actual = repository.Count;

            //Validation
            var expect = 3;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Indexer_Get_ReturnMethodinfo()
        {
            //Arrange
            var repository = TestMethodRepository;

            //Act
            var actual = Enumerable.Range(0, 3).Select(n => repository[n].Name).ToList();

            //Validation
            var expect = new List<string> { "Test1", "Test2", "Test3" };
            Assert.IsTrue(actual.SequenceEqual(expect));
        }

        [TestMethod]
        public void GetMethodNames_Get_ReturnMethodNames()
        {
            //Arrange
            var repository = TestMethodRepository;

            //Act
            var actual = repository.GetMethodNames().ToList();

            //Validation
            var expect = new List<string> { "Test1", "Test2", "Test3" };
            Assert.IsTrue(actual.SequenceEqual(expect));
        }

        [TestMethod]
        public void Indexer_CheckUpperBounded_ThrowIndexOutOfRangeException()
        {
            Action action = () =>
            {
                var methodInfo = TestMethodRepository[3];
            };

            action.AssertHandleException<ArgumentException>();
        }

        [TestMethod]
        public void Indexer_CheckLowerBounded_ThrowIndexOutOfRangeException()
        {
            Action action = () =>
            {
                var methodInfo = TestMethodRepository[-1];
            };

            action.AssertHandleException<ArgumentException>();
        }
    }
}
