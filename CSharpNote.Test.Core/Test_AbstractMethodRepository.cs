using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Core.Implements;
using CSharpNote.Common.Attributes;

namespace CSharpNote.Test.Core
{
    [TestClass]
    public class Test_AbstractMethodRepository
    {
        [MarkedRepositoryAttribue]
        private class testMethodRepository : AbstractMethodRepository
        {
            [MarkedItem]
            public void test1()
            {
            }

            [MarkedItem]
            public void test2()
            {
            }

            [MarkedItem]
            public void test3()
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
            //Arrange
            var repository = TestMethodRepositories;

            //Act
            try
            {
                var name = repository.RepositoryName;
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
        public void RepositoryName_Get_ReturnRepositoryName()
        {
            //Arrange
            var repository = TestMethodRepository;

            //Act
            var actual = repository.RepositoryName;

            //Assert
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

            //Assert
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

            //Assert
            var expect = new List<string> { "test1", "test2", "test3" };
            for (var i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(expect[i], actual[i]);
            }
        }

        [TestMethod]
        public void GetMethodNames_Get_ReturnMethodNames()
        {
            //Arrange
            var repository = TestMethodRepository;

            //Act
            var actual = repository.GetMethodNames().ToList();

            //Assert
            var expect = new List<string> { "test1", "test2", "test3" };
            for (var i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(expect[i], actual[i]);
            }
        }

        [TestMethod]
        public void Indexer_CheckUpperBounded_ThrowIndexOutOfRangeException()
        {
            //Arrange
            var repository = TestMethodRepository;

            //Act
            try
            {
                var methodInfo = repository[3];
                Assert.Fail("ExceptionMustBeThrown");
            }
            //Assert
            catch (IndexOutOfRangeException e)
            {
            }
            catch (Exception e)
            {
                Assert.Fail("IncorrectException");
            }
        }

        [TestMethod]
        public void Indexer_CheckLowerBounded_ThrowIndexOutOfRangeException()
        {
            //Arrange
            var repository = TestMethodRepository;

            //Act
            try
            {
                var methodInfo = repository[-1];
                Assert.Fail("ExceptionMustBeThrown");
            }
            //Assert
            catch (IndexOutOfRangeException e)
            {
            }
            catch (Exception e)
            {
                Assert.Fail("IncorrectException");
            }
        }
    }
}
