using CSharpNote.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Common.Test
{
    [TestClass]
    public class Test_StringExtensions
    {
        [TestMethod]
        public void IsNullOrEmpty()
        {
            Assert.IsTrue(string.Empty.IsNullOrEmpty());
            Assert.IsFalse("Test".IsNullOrEmpty());
        }

        [TestMethod]
        public void Format()
        {
            Assert.AreEqual("test", "{0}".Format(new[]
            {
                "test"
            }));

            Assert.AreEqual("", "".Format());

            Assert.AreEqual("abcd", "{0}{1}{2}{3}".Format(new[]
            {
                "a",
                "b",
                "c",
                "d"
            }));
        }
    }
}