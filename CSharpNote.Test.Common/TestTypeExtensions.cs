﻿using System.Linq;
using CSharpNote.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Common.Test
{
    [TestClass]
    public class TestTypeExtensions
    {
        [TestMethod]
        public void GetMatchInterface_Get_ReturnMatchInterfaceType()
        {
            //Arrange
            var type = typeof (TestObject);

            //Act
            var actual = type.GetMatchInterface();

            //Validation
            var expect = typeof (ITestObject);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void GetMatchConstructor_Get_ReturnMatchConstructor()
        {
            //Arrange
            var type = typeof (TestObject);

            //Act
            var actual = type.GetMatchConstructor();

            //Validation
            var expect = type.GetConstructors().First();
            Assert.AreEqual(expect, actual);
        }

        public interface ITestObject
        {
        }

        public class TestObject : ITestObject
        {
            public TestObject(ITestObject obj)
            {
            }
        }
    }
}