using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Extendsions;

namespace CSharpNote.Data.ProjectMethod.Implement.Validation
{
    /// <summary>
    /// 驗証規則元件
    /// </summary>
    public class ValidationSequenceComponent
    {
        public int Return(ValidationRecord record, IEnumerable<char> code)
        {
            int value;
            var temp = string.Concat(code);

            if (!Int32.TryParse(temp, out value))
            {
                return -1;
            }

            return value;
        }

        public IEnumerable<char> ReverseTake(ValidationRecord record, IEnumerable<char> code)
        {
            if (record.IsReverse && record.Notification != string.Empty && record.Take != null)
            {
                var take = record.Take.GetValueOrDefault();
                code = code.Take(take);
                code = code.Reverse();
            }

            return code;
        }

        public IEnumerable<char> Take(ValidationRecord record, IEnumerable<char> code)
        {
            if (record.Take != null)
            {
                var take = record.Take.GetValueOrDefault();
                code = code.Take(take);
            }

            return code;
        }

        public IEnumerable<char> Skip(ValidationRecord record, IEnumerable<char> code)
        {
            if (record.Skip != null)
            {
                var skip = record.Skip.GetValueOrDefault();
                code = code.Skip(skip);
            }

            return code;
        }

        public IEnumerable<char> Reverse(ValidationRecord record, IEnumerable<char> code)
        {
            if (record.IsReverse)
            {
                code = code.Reverse();
            }

            return code;
        }

        public IEnumerable<char> AfterNotification(ValidationRecord record, IEnumerable<char> code)
        {
            if (!record.Notification.IsNullOrEmpty() && !record.IsReverse)
            {
                code = code.SkipWhile(c => c != record.Notification.First()).Skip(1);
            }

            return code;
        }

        public IEnumerable<char> BeforeNotification(ValidationRecord record, IEnumerable<char> code)
        {
            if (!record.Notification.IsNullOrEmpty() && record.IsReverse)
            {
                code = code.TakeWhile(c => c != record.Notification.First());
            }

            return code;
        }
    }
}
