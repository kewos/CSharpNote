﻿using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpNote.Core.Test
{
    [TestClass]
    public class TestAbstractMethodRepository
    {
        private AbstractRepository TestRepository
        {
            get { return new testRepository(); }
        }

        private AbstractRepository TestRepositories
        {
            get { return new testRepositories(); }
        }

        [TestMethod]
        public void RepositoryName_Get_ReturnRepositoryName()
        {
            //Arrange
            var repository = TestRepository;

            //Act
            var actual = repository.RepositoryName;

            //Validation
            var expect = "test";
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Count_Get_ReturnRepositoryCount()
        {
            //Arrange
            var repository = TestRepository;

            //Act
            var actual = repository.Count;

            //Validation
            var expect = 3;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void GetMethodNames_Get_ReturnMethodNames()
        {
            //Arrange
            var repository = TestRepository;

            //Act
            var actual = repository.GetMethodNames().ToList();

            //Validation
            var expect = new List<string> {"Test1", "Test2", "Test3"};
            Assert.IsTrue(actual.SequenceEqual(expect));
        }

        [TestMethod]
        public void Indexer_CheckUpperBounded_ThrowIndexOutOfRangeException()
        {
            Action action = () => { var methodInfo = TestRepository[3]; };

            action.AssertHandleException<ArgumentException>();
        }

        [TestMethod]
        public void Indexer_CheckLowerBounded_ThrowIndexOutOfRangeException()
        {
            Action action = () => { var methodInfo = TestRepository[-1]; };

            action.AssertHandleException<ArgumentException>();
        }

        [AopClassAttribue]
        private class testRepository : AbstractRepository
        {
            [AopTarget]
            public void Test1()
            {
            }

            [AopTarget]
            public void Test2()
            {
            }

            [AopTarget]
            public void Test3()
            {
            }
        }

        [AopClassAttribue]
        private class testRepositories : AbstractRepository
        {
        }
    }
}