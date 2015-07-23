using CSharpNote.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Common.Test
{
    [TestClass]
    public class Test_StringExtensions
    {
        [TestMethod]
        public void IsNullOrEmpty_InputEmpty_OutputTrue()
        {
            //Arrange
            var s = string.Empty;

            //Act
            var actual = s.IsNullOrEmpty();

            //Validation
            var expect = true;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void IsNullOrEmpty_InputTest_OutputFalse()
        {
            //Arrange
            var s = "Test";

            //Act
            var actual = s.IsNullOrEmpty();

            //Validation
            var expect = false;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Format_InputNothing_OutputNothing()
        {
            //Act
            var actual = "".Format();

            //Validation
            var expect = "";
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Format_InputABCD_OutputABCD()
        {
            //Arrange
            var set = new[] {"a", "b", "c", "d"};

            //Act
            var actual = "{0}{1}{2}{3}".Format(set);

            //Validation
            var expect = "abcd";
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Format_InputString_OutputString()
        {
            //Arrange
            var set = new[] {"test"};

            //Act
            var actual = "{0}".Format(set);

            //Validation
            var expect = "test";
            Assert.AreEqual(expect, actual);
        }
    }
}