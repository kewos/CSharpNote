using System;
using CSharpNote.Common.Extendsions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Test.Core
{
    [TestClass]
    public class Test_ActionExtension
    {
        [TestMethod]
        public void ExcauteAndCatchException_ThrowException_ReturnExceptionResult()
        {
            //Arrange
            Action action = () =>
            {
                throw new Exception("TestException");
            };

            //Act
            var actual = action.ExcauteAndCatchException();

            //Assert
            var expect = "Exception:TestException";
            Assert.AreEqual(actual, expect);
        }
    }
}