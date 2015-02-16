using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpNote.Common.Extendsions
{
    public static class ParameterGuardExtensions
    {
        /// <summary>
        /// 假如predicate為假丟出錯誤訊息
        /// </summary>
        private static void Assert<TException>(bool predicate, string message)
            where TException : Exception
        {
            if (!predicate)
            {
                throw (TException)Activator.CreateInstance(typeof (TException), message);
            }
        }

        /// <summary>
        /// 假如predicate為假丟出錯誤訊息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Assert<T>(this T obj, Func<T, bool> predicate, string message)
        {
            Assert<Exception>(predicate(obj), "SomeException");
        }

        /// <summary>
        /// 預測不是Null
        /// </summary>
        public static T AssertNotNull<T>(this T parameter)
        {
            Assert<ArgumentNullException>(parameter != null, string.Format("{0}IsNull", parameter));
            return parameter;
        }

        /// <summary>
        /// 預測不是空字串
        /// </summary>
        public static string AssertNotEmpty(this string parameter)
        {
            Assert<ArgumentNullException>(parameter.Length > 0, string.Format("{0}IsNull", parameter));
            return parameter;
        }

        /// <summary>
        /// 預測字串長度範圍
        /// </summary>
        public static string AssertBetweenRange(this string parameter, int start, int end)
        {
            Assert<ArgumentException>(parameter.Length >= start && parameter.Length <= end, string.Format("{0}NoAtRange", parameter));
            return parameter;
        }

        /// <summary>
        /// 預設是否大於或大於等於
        /// </summary>
        public static T AssertGreaterThan<T>(this T parameter, T target, bool canEqual = true) 
            where T : IComparable<T>
        {
            var state = (canEqual) ? parameter.CompareTo(target) >= 0 : parameter.CompareTo(target) > 0;
            Assert<ArgumentException>(state, string.Format("{0}GreaterThan{1}", parameter, target));
            return parameter;
        }

        /// <summary>
        /// 預設是否小於或小於等於
        /// </summary>
        public static T AssertLessThan<T>(this T parameter, T target, bool canEqual = true) 
            where T : IComparable<T>
        {
            var state = (canEqual) ? parameter.CompareTo(target) <= 0 : parameter.CompareTo(target) < 0;
            Assert<ArgumentException>(state, string.Format("{0}LessThan{1}", parameter, target));
            return parameter;
        }

        /// <summary>
        /// 預測是否於範圍內
        /// </summary>
        public static T AssertBetweenRange<T>(this T parameter, T start, T end, bool canEqual = true) 
            where T : IComparable<T>
        {
            parameter.AssertGreaterThan(start, canEqual);
            parameter.AssertLessThan(end, canEqual);
            return parameter;
        }

        /// <summary>
        /// 預測是否相等
        /// </summary>
        public static T AssertEqualWith<T>(this T parameter, T target)
            where T : IComparable<T>
        {
            Assert<ArgumentException>(parameter.CompareTo(target) == 0, string.Format("{0}:IsNotEqual", parameter));
            return parameter;
        }

        /// <summary>
        /// 預測是否為Empty或Null
        /// </summary>
        public static IEnumerable<T> AssertNotEmptyOrNull<T>(this IEnumerable<T> parameter)
        {
            parameter.AssertNotNull();
            Assert<ArgumentNullException>(parameter.Any(), string.Format("{0}:IsEmpty", parameter));
            return parameter;
        }

        /// <summary>
        /// 預測字串是否為format結尾
        /// </summary>
        public static string AssertEndWith(this string parameter, string format)
        {
            Assert<ArgumentException>(parameter.EndsWith(format), string.Format("{0}:IncorrectFormat", parameter));
            return parameter;
        }

        /// <summary>
        /// 預測字串是否為format開頭
        /// </summary>
        public static string AssertStartWith(this string parameter, string format)
        {
            Assert<ArgumentException>(parameter.StartsWith(format), string.Format("{0}:IncorrectFormat", parameter));
            return parameter;
        }
    }
}