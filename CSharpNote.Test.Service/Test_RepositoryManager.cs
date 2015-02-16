using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Core.Implements;
using CSharpNote.Service.CSharpNoteService;
using CSharpNote.Test.Lib.Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Test.Service
{
    [TestClass]
    public class Test_RepositoryManager
    {
        private class testMethodRepository : AbstractMethodRepository
        {
        }

        private IEnumerable<testMethodRepository> GetRepositories
        {
            get
            {
                yield return new testMethodRepository();
                yield return new testMethodRepository();
                yield return new testMethodRepository();
            }
        }

        private CSharperNoteService TestCSharpService
        {
            get
            {
                return new CSharperNoteService(GetRepositories);
            }
        }

        [TestMethod]
        public void GetRepositoryNames_Get_ReturnRepositoryNames()
        {
            //Arrange
            var repositoryManager = TestCSharpService;

            //Act
            var actual = repositoryManager.GetRepositoryNames().ToList();

            //Assert
            var expect = new List<string> {"test", "test", "test"};
            for (var i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(expect[i], actual[i]);
            }
        }

        [TestMethod]
        public void Indexer_Get_ReturnRepository()
        {
            //Arrange
            var repositoryManager = TestCSharpService;

            //Act
            var actual = Enumerable.Range(0, 3).Select(n => repositoryManager[n].RepositoryName).ToList();

            //Assert
            var expect = new List<string> { "test", "test", "test" };
            for (var i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(expect[i], actual[i]);
            }
        }

        [TestMethod]
        public void Indexer_CheckLowerBounded_ThrowException()
        {
            Action action = () =>
            {
                var methodInfo = TestCSharpService[-1];
            };

            action.AssertHandleException<ArgumentException>();
        }

        [TestMethod]
        public void Indexer_CheckUpperBounded_ThrowException()
        {
            Action action = () =>
            {
                var methodInfo = TestCSharpService[3];
            };

            action.AssertHandleException<ArgumentException>();
        }
    }
}
