using CSharpNote.Common.Extendsions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Test.Common
{
    [TestClass]
    public class Test_ObjectExtensions
    {
        [TestMethod]
        public void ToConsole_InputPrefixSuffix_ReturnResult()
        {
            //Arrange
            var str = "test";

            //Act
            var actual = str.ToConsole("test", "test");

            //Validation
            var expect = "test test test";
            Assert.AreEqual(expect, actual);
        }
    }
}