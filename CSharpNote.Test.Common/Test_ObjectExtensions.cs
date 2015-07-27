﻿using CSharpNote.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Common.Test
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