﻿using System;
using CSharpNote.Common.Extendsions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Test.Common
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

        [TestMethod]
        public void CaculateExcuteTime_ActionIsNull_ThrowArgumentNullException()
        {
            //Arrange
            Action action = null;

            //Act
            try
            {
                var actual = action.CaculateExcuteTime();
                Assert.Fail("ExceptionMustBeThrown");
            }
            //Assert
            catch (ArgumentNullException e)
            {
            }
            catch (Exception e)
            {
                Assert.Fail("IncorrectException");
            }
        }

        [TestMethod]
        public void CaculateExcuteTime_InputAction_ExecuteAction()
        {
            //Arrange
            var actual = 0;
            Action action = () => actual++;

            //Act
            action.ExcauteAndCatchException();

            //Assert
            var expect = 1;
            Assert.AreEqual(actual, expect);
        }
    }
}