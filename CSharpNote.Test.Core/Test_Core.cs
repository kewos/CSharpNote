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
        public class testRepository : AbstractMethodRepository
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
         
        [TestMethod]
        public void AbstractMethodRepository_Get_MethodInfos_Count_Equal_3()
        {
            //Arrange
            var repository = new testRepository();

            //Act
            var actual = repository;

            //Assert
            var expect = 3;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void AbstractMethodRepository_Get_MethodInfos_Content_Match()
        {
            //Arrange
            var repository = new testRepository();

            //Act
            var actual = repository.MethodInfos.Select(n => n.Name).ToList();

            //Assert
            var expect = new List<string> { "test1", "test2", "test3" };
            for (var i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expect[i], actual[i]);
            }
        }
    }
}
