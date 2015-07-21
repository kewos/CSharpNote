using System;
using System.Collections.Generic;
using CSharpNote.Common.Extensions;
using CSharpNote.Common.Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Common.Test
{
    [TestClass]
    public class Test_ValidationExtensions
    {
        #region Test_AssertNotEmpty
        [TestMethod]
        public void ValidationNotEmpty_InputStringNull_ThrowException()
        {
            Action action = () => "".ValidationNotEmpty();
            action.AssertHandleException<ArgumentNullException>();
        }

        [TestMethod]
        public void ValidationNotEmpty_NotNullString_DoNothing()
        {
            Action action = () => "Test".ValidationNotEmpty();
            action.AssertHandleException();
        }
        #endregion

        #region Test_AssertBetweenRange
        [TestMethod]
        public void ValidationBetweenRange_Rang2To5InputLength6String_ThrowException()
        {
            Action action = () => "TestTe".ValidationBetweenRange(2, 5);
            action.AssertHandleException<ArgumentException>();
        }

        [TestMethod]
        public void ValidationBetweenRange_Rang2To5InputLength1String_ThrowException()
        {
            Action action = () => "T".ValidationBetweenRange(2, 5);
            action.AssertHandleException<ArgumentException>();
        }

        [TestMethod]
        public void ValidationBetweenRange_Rang2To5InputLength3String_DoNothing()
        {
            Action action = () => "Tes".ValidationBetweenRange(2, 5);
            action.AssertHandleException();
        }
        #endregion

        #region Test_AssertGreaterThan
        [TestMethod]
        public void ValidationGreaterThan_Input1Target1CanEqualTrue_DoNothing()
        {
            Action action = () => 1.ValidationGreaterThan(1);
            action.AssertHandleException();
        }

        [TestMethod]
        public void ValidationGreaterThan_Input1Target1CanEqualFalse_ThrowException()
        {
            Action action = () => 1.ValidationGreaterThan(1, false);
            action.AssertHandleException<ArgumentException>();
        }

        [TestMethod]
        public void ValidationGreaterThan_Input2Target1CanEqualFalse_DoNothing()
        {
            Action action = () => 2.ValidationGreaterThan(1, false);
            action.AssertHandleException();
        }
        #endregion

        #region Test_AssertLessThan
        [TestMethod]
        public void ValidationLessThan_Input1Target1CanEqualTrue_DoNothing()
        {
            Action action = () => 1.ValidationLessThan(1);
            action.AssertHandleException();
        }

        [TestMethod]
        public void ValidationLessThan_Input1Target1CanEqualFalse_ThrowException()
        {
            Action action = () => 1.ValidationLessThan(1, false);
            action.AssertHandleException<ArgumentException>();
        }

        [TestMethod]
        public void ValidationLessThan_Input0Target1EqualFalse_DoNothing()
        {
            Action action = () => 0.ValidationLessThan(1, false);
            action.AssertHandleException();
        }
        #endregion

        #region Test_AssertLessThan
        [TestMethod]
        public void ValidationBetweenRange_Input1Between1To5CanEqualTrue_DoNothing()
        {
            Action action = () => 1.ValidationBetweenRange(1, 5);
            action.AssertHandleException();
        }

        [TestMethod]
        public void ValidationBetweenRange_Input5Between1To5CanEqualTrue_DoNothing()
        {
            Action action = () => 5.ValidationBetweenRange(1, 5);
            action.AssertHandleException();
        }

        [TestMethod]
        public void ValidationBetweenRange_Input1Between1To5CanEqualFalse_ThrowException()
        {
            Action action = () => 1.ValidationBetweenRange(1, 5, false);
            action.AssertHandleException<ArgumentException>();
        }

        [TestMethod]
        public void ValidationBetweenRange_Input5Between1To5CanEqualFalse_ThrowException()
        {
            Action action = () => 5.ValidationBetweenRange(1, 5, false);
            action.AssertHandleException<ArgumentException>();
        }
        #endregion

        #region Test ValidationEqualWith
        [TestMethod]
        public void ValidationEqualWith_Input1EqualWith1_DoNothing()
        {
            Action action = () => 1.ValidationEqualWith(1);
            action.AssertHandleException();
        }

        [TestMethod]
        public void ValidationEqualWith_Input2EqualWith1_DoNothing()
        {
            Action action = () => 2.ValidationEqualWith(1);
            action.AssertHandleException<ArgumentException>();
        }
        #endregion

        #region Test ValidationNotEmptyAndNull
        [TestMethod]
        public void ValidationEqualWith_InputListHasItem_DoNothing()
        {
            var list = new List<int> {1};
            Action action = () =>  list.ValidationNotEmptyAndNull();
            action.AssertHandleException();
        }

        [TestMethod]
        public void ValidationEqualWith_InputEmptyList_ThrowException()
        {
            var list = new List<int> ();
            Action action = () => list.ValidationNotEmptyAndNull();
            action.AssertHandleException<ArgumentNullException>();
        }

        [TestMethod]
        public void ValidationEqualWith_InputNullList_ThrowException()
        {
            var list = (List<int>)null;
            Action action = () => list.ValidationNotEmptyAndNull();
            action.AssertHandleException<ArgumentNullException>();
        }
        #endregion

        #region Test ValidationEndWith
        [TestMethod]
        public void ValidationEndWith_InputTestFormatTest_DoNothing()
        {
            Action action = () =>  "Test".ValidationEndWith("Test");
            action.AssertHandleException();
        }

        [TestMethod]
        public void ValidationEndWith_InputTestFormatTestT_DoNothing()
        {
            Action action = () => "Test".ValidationEndWith("TestT");
            action.AssertHandleException<ArgumentException>();
        }
        #endregion

        #region Test ValidationStartWith
        [TestMethod]
        public void ValidationStartWith_InputTestFormatTest_DoNothing()
        {
            Action action = () => "Test".ValidationStartWith("Test");
            action.AssertHandleException();
        }

        [TestMethod]
        public void ValidationStartWith_InputTestFormatTestT_DoNothing()
        {
            Action action = () => "Test".ValidationStartWith("TestT");
            action.AssertHandleException<ArgumentException>();
        }
        #endregion
    }
}