using System;
using System.Collections.Generic;
using CSharpNote.Common.Extendsions;
using CSharpNote.Test.Lib.Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Test.Common
{
    [TestClass]
    public class Test_ParameterGuardExtensions
    {
        #region Test_AssertNotEmpty
        [TestMethod]
        public void AssertNotEmpty_InputStringNull_ThrowException()
        {
            Action action = () => "".AssertNotEmpty();
            action.AssertHandleException<ArgumentNullException>();
        }

        [TestMethod]
        public void AssertNotEmpty_NotNullString_DoNothing()
        {
            Action action = () => "Test".AssertNotEmpty();
            action.AssertHandleException();
        }
        #endregion

        #region Test_AssertBetweenRange
        [TestMethod]
        public void AssertBetweenRange_Rang2To5InputLength6String_ThrowException()
        {
            Action action = () => "TestTe".AssertBetweenRange(2, 5);
            action.AssertHandleException<ArgumentException>();
        }

        [TestMethod]
        public void AssertBetweenRange_Rang2To5InputLength1String_ThrowException()
        {
            Action action = () => "T".AssertBetweenRange(2, 5);
            action.AssertHandleException<ArgumentException>();
        }

        [TestMethod]
        public void AssertBetweenRange_Rang2To5InputLength3String_DoNothing()
        {
            Action action = () => "Tes".AssertBetweenRange(2, 5);
            action.AssertHandleException();
        }
        #endregion

        #region Test_AssertGreaterThan
        [TestMethod]
        public void AssertGreaterThan_Input1Target1CanEqualTrue_DoNothing()
        {
            Action action = () => 1.AssertGreaterThan(1);
            action.AssertHandleException();
        }

        [TestMethod]
        public void AssertGreaterThan_Input1Target1CanEqualFalse_ThrowException()
        {
            Action action = () => 1.AssertGreaterThan(1, false);
            action.AssertHandleException<ArgumentException>();
        }

        [TestMethod]
        public void AssertGreaterThan_Input2Target1CanEqualFalse_DoNothing()
        {
            Action action = () => 2.AssertGreaterThan(1, false);
            action.AssertHandleException();
        }
        #endregion

        #region Test_AssertLessThan
        [TestMethod]
        public void AssertLessThan_Input1Target1CanEqualTrue_DoNothing()
        {
            Action action = () => 1.AssertLessThan(1);
            action.AssertHandleException();
        }

        [TestMethod]
        public void AssertLessThan_Input1Target1CanEqualFalse_ThrowException()
        {
            Action action = () => 1.AssertLessThan(1, false);
            action.AssertHandleException<ArgumentException>();
        }

        [TestMethod]
        public void AssertLessThan_Input0Target1EqualFalse_DoNothing()
        {
            Action action = () => 0.AssertLessThan(1, false);
            action.AssertHandleException();
        }
        #endregion

        #region Test_AssertLessThan
        [TestMethod]
        public void AssertBetweenRange_Input1Between1To5CanEqualTrue_DoNothing()
        {
            Action action = () => 1.AssertBetweenRange(1, 5);
            action.AssertHandleException();
        }

        [TestMethod]
        public void AssertBetweenRange_Input5Between1To5CanEqualTrue_DoNothing()
        {
            Action action = () => 5.AssertBetweenRange(1, 5);
            action.AssertHandleException();
        }

        [TestMethod]
        public void AssertBetweenRange_Input1Between1To5CanEqualFalse_ThrowException()
        {
            Action action = () => 1.AssertBetweenRange(1, 5, false);
            action.AssertHandleException<ArgumentException>();
        }

        [TestMethod]
        public void AssertBetweenRange_Input5Between1To5CanEqualFalse_ThrowException()
        {
            Action action = () => 5.AssertBetweenRange(1, 5, false);
            action.AssertHandleException<ArgumentException>();
        }
        #endregion

        #region Test AssertEqualWith
        [TestMethod]
        public void AssertEqualWith_Input1EqualWith1_DoNothing()
        {
            Action action = () => 1.AssertEqualWith(1);
            action.AssertHandleException();
        }

        [TestMethod]
        public void AssertEqualWith_Input2EqualWith1_DoNothing()
        {
            Action action = () => 2.AssertEqualWith(1);
            action.AssertHandleException<ArgumentException>();
        }
        #endregion

        #region Test AssertNotEmptyOrNull
        [TestMethod]
        public void AssertEqualWith_InputListHasItem_DoNothing()
        {
            var list = new List<int> {1};
            Action action = () =>  list.AssertNotEmptyOrNull();
            action.AssertHandleException();
        }

        [TestMethod]
        public void AssertEqualWith_InputEmptyList_ThrowException()
        {
            var list = new List<int> ();
            Action action = () => list.AssertNotEmptyOrNull();
            action.AssertHandleException<ArgumentNullException>();
        }

        [TestMethod]
        public void AssertEqualWith_InputNullList_ThrowException()
        {
            var list = (List<int>)null;
            Action action = () => list.AssertNotEmptyOrNull();
            action.AssertHandleException<ArgumentNullException>();
        }
        #endregion

        #region Test AssertEndWith
        [TestMethod]
        public void AssertEndWith_InputTestFormatTest_DoNothing()
        {
            Action action = () =>  "Test".AssertEndWith("Test");
            action.AssertHandleException();
        }

        [TestMethod]
        public void AssertEndWith_InputTestFormatTestT_DoNothing()
        {
            Action action = () => "Test".AssertEndWith("TestT");
            action.AssertHandleException<ArgumentException>();
        }
        #endregion

        #region Test AssertStartWith
        [TestMethod]
        public void AssertStartWith_InputTestFormatTest_DoNothing()
        {
            Action action = () => "Test".AssertStartWith("Test");
            action.AssertHandleException();
        }

        [TestMethod]
        public void AssertStartWith_InputTestFormatTestT_DoNothing()
        {
            Action action = () => "Test".AssertStartWith("TestT");
            action.AssertHandleException<ArgumentException>();
        }
        #endregion
    }
}