using System.Linq;
using CSharpNote.Common.Extendsions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Test.Core
{
    [TestClass]
    public class Test_TypeExtensions
    {
        public interface ITestObject
        {
             
        }

        public class TestObject : ITestObject
        {
            public TestObject(ITestObject obj)
            {
            }
        }

        [TestMethod]
        public void GetMatchInterface_Get_ReturnMatchInterfaceType()
        {
            //Arrange
            var type = typeof(TestObject);

            //Act
            var actual = type.GetMatchInterface();

            //Assert
            var expect = typeof(ITestObject);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void GetMatchConstructor_Get_ReturnMatchConstructor()
        {
            //Arrange
            var type = typeof(TestObject);

            //Act
            var actual = type.GetMatchConstructor();

            //Assert
            var expect = type.GetConstructors().FirstOrDefault();
            Assert.AreEqual(expect, actual);
        }
    }
}