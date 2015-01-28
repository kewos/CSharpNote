using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleDisplay.Common;
using ConsoleDisplay.Core.Contracts;
using ConsoleDisplay.Core.Implements;

namespace ConsoleDisplay.Test.Core
{


    [TestClass]
    public class Test_AbstractMethodRepository
    {
        [DisplayClassAttribue]
        public class testRepository : AbstractMethodRepository
        {
            [DisplayMethod]
            public void test1()
            {
            }

            [DisplayMethod]
            public void test2()
            {
            }

            [DisplayMethod]
            public void test3()
            {
            }
        }
         
        [TestMethod]
        public void MethodInfos_Get_Equal3()
        {
            //Arrange
            var repository = new testRepository();

            //Act
            var actual = repository.MethodInfos.Count;

            //Assert
            var expect = 3;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void MethodInfos_Get_ItemEqual()
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
