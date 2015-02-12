using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Core.Implements;
using CSharpNote.Data.RepositoryManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Test.Data
{
    [TestClass]
    public class Test_RepositoryManager
    {
        public class testMethodRepository : AbstractMethodRepository
        {
        }

        public IEnumerable<testMethodRepository> GetRepositories
        {
            get
            {
                yield return new testMethodRepository();
                yield return new testMethodRepository();
                yield return new testMethodRepository();
            }
        }

        public RepositoryManager TestRepositoryManager
        {
            get
            {
                return new RepositoryManager(GetRepositories);
            }
        }

        [TestMethod]
        public void RepositoryManager_Get_Repository_Names()
        {
            //Arrange
            var repositoryManager = TestRepositoryManager;

            //Act
            var actual = repositoryManager.GetRepositoryNames().ToList();

            //Assert
            var expect = new List<string> {"test", "test", "test"};
            for (var i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expect[i], actual[i]);
            }
        }

        [TestMethod]
        public void RepositoryManager_Get_Repository_By_Indexer()
        {
            //Arrange
            var repositoryManager = TestRepositoryManager;

            //Act
            var actual = Enumerable.Range(0, 3).Select(n => repositoryManager[n].RepositoryName).ToList();

            //Assert
            var expect = new List<string> { "test", "test", "test" };
            for (var i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expect[i], actual[i]);
            }
        }

        [TestMethod]
        public void RepositoryManager_Check_Index_Lower_Bounded()
        {
            //Arrange
            var repositoryManager = TestRepositoryManager;

            //Act
            try
            {
                var repository = repositoryManager[-1];
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
        public void RepositoryManager_Check_Index_Upper_Bounded()
        {
            //Arrange
            var repositoryManager = TestRepositoryManager;

            //Act
            try
            {
                var repository = repositoryManager[3];
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
