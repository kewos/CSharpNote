using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Common.Extension
{
    public static class AssertExtensions
    {
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