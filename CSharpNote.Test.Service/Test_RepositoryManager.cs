using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Core.Implements;
using CSharpNote.Common.Extension;
using CSharpNote.Service.CSharpNoteService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Service.Test
{
    [TestClass]
    public class Test_RepositoryManager
    {
        private class TestMethodRepository : AbstractMethodRepository
        {
        }

        private IEnumerable<TestMethodRepository> GetRepositories
        {
            get
            {
                yield return new TestMethodRepository();
                yield return new TestMethodRepository();
                yield return new TestMethodRepository();
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

            //Validation
            var expect = new List<string> { "Test", "Test", "Test" };
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

            //Validation
            var expect = new List<string> { "Test", "Test", "Test" };
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
