using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpNote.Common.Extendsions
{
    public static class ParameterGuardExtensions
    {
        public static void Assert<TException>(bool predicate, string message)
            where TException : Exception
        {
            if (!predicate)
            {
                throw (TException)Activator.CreateInstance(typeof (TException), message);
            }
        }

        public static void Assert<T>(this T obj, Func<T, bool> predicate, string message)
        {
            Assert<Exception>(predicate(obj), "SomeException");
        }

        public static void AssertNoNull(this object parameter)
        {
            Assert<ArgumentNullException>(parameter == null, string.Format("{0}IsNull", parameter));
        }

        public static void AssertNoEmpty(this string parameter)
        {
            Assert<Exception>(parameter.Length > 0, string.Format("{0}IsNull", parameter));
        }

        public static void AssertBetweenRange(this string parameter, int start, int end)
        {
            Assert<Exception>(parameter.Length >= start && parameter.Length <= end, string.Format("{0}NoAtRange", parameter));
        }

        public static void AssertGreaterThan<T>(this T parameter, T target) 
            where T : IComparable<T>
        {
            Assert<Exception>(parameter.CompareTo(target) >= 0, string.Format("{0}GreaterThan{1}", parameter, target));
        }

        public static void AssertLessThan<T>(this T parameter, T target) 
            where T : IComparable<T>
        {
            Assert<ArgumentException>(parameter.CompareTo(target) <= 0, string.Format("{0}LessThan{1}", parameter, target));
        }

        public static void AssertBetweenRange<T>(this T parameter, T start, T end) 
            where T : IComparable<T>
        {
            parameter.AssertGreaterThan(start);
            parameter.AssertLessThan(end);
        }

        public static void AssertEqualWith<T>(this T parameter, T target)
            where T : IComparable<T>
        {
            Assert<ArgumentException>(parameter.CompareTo(target) == 0, string.Format("{0}:IsNotEqual", parameter));
        }

        public static void AssertNotEmptyAndNull<T>(this IEnumerable<T> parameter)
        {
            parameter.AssertNoNull();
            Assert<ArgumentNullException>(parameter.Any(), string.Format("{0}:IsEmpty", parameter));
        }
    }
}