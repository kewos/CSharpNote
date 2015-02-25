using System.Linq;
using CSharpNote.Common.Extendsions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Test.Common
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

            //Validation
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

            //Validation
            var expect = type.GetConstructors().First();
            Assert.AreEqual(expect, actual);
        }
    }
}