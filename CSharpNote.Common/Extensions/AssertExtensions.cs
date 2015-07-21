using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Common.Extension
{
    public static class AssertExtensions
    {
        /// <summary>
        /// 預測是否會產生TException
        /// </summary>
        public static void AssertHandleException<TException>(this Action action)
            where TException : Exception
        {
            try
            {
                action();
                Assert.Fail("ExceptionMustBeThrown");
            }
            catch (TException e)
            {
            }
            catch (Exception e)
            {
                Assert.Fail("IncorrectException");
            }
        }

        /// <summary>
        /// 預測不產生例外
        /// </summary>
        public static void AssertHandleException(this Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                Assert.Fail("IncorrectException");
            }
        }
    }
}